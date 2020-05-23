using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Volcano
{
	public class Raspoznavanie
	{
		int attr_q; //quantity of attributes
		int cl_q; //quantity of classes a, b, c...
		int[] cl_len; //classes length a1 a2 ... an
		int[,] matrix;
		List<int[]> M;
		List<List<int>> feature;
		string logic;
		List<double> weight;

		public Raspoznavanie(int[] classes_length, int[,] matrix)
		{
			//ширина матрицы =)
			this.attr_q = matrix.GetLength(1);
			//количество классов: а, б, с...
			this.cl_q = classes_length.Length;
			//количество подклассов в каждом и классов: а1, а2...
			this.cl_len = new int[cl_q];
			int sum = 0, k = 0;
			foreach (var c in classes_length)
			{
				this.cl_len[k++] = c;
				sum += c;
			}

			//исхлодная матрица признаков
			this.matrix = new int[sum, attr_q];
			for (int i = 0; i < sum; i++)
				for (int j = 0; j < attr_q; j++)
					this.matrix[i, j] = matrix[i, j];
			CreateM(sum);
			DeleteFromM(FindMinQof1());
			MakeClusters();
			CalculateWeight();
		}

		private void CreateM(int sum_quantity) //на входе общее количество подклассов
		{
			int len = sum_quantity;
			int sum = 0;
			foreach (var c in cl_len)
			{
				sum += (len - c) * c;
				len -= c;
			}

			M = new List<int[]>();
			int this_class = 0, next_class = 0;
			for (int c_class = 0; c_class < cl_q; c_class++)
			{
				//сложение по модулю 2
				//признаков каждого подкласса с признаками подклассов других классов, без повторений
				this_class = next_class; //начало индексов этого класса
				next_class += cl_len[c_class]; //начало индексов следующего класса
				for (int c_subclass = this_class; c_subclass < next_class && c_subclass < sum_quantity; c_subclass++)
					for (int j = next_class; j < sum_quantity; j++)
						M.Add(AddMod2(c_subclass, j));
			}

		}

		private int[] AddMod2(int first, int second)
		{
			int[] temp = new int[attr_q];
			// сложение по модулю 2 двух строк поэлементно 
			for (int j = 0; j < attr_q; j++)
				temp[j] = (matrix[first, j] + matrix[second, j]) % 2;
			return temp;
		}

		private int FindMinQof1()
		{
			int minQ = attr_q;
			int minI = 0;
			for (int i = 0; i < M.Count(); i++)
			{
				int Q = 0;
				for (int j = 0; j < attr_q; j++)
					if (M[i][j] == 1) Q++;
				if (minQ >= Q)
				{
					minQ = Q;
					minI = i;
				}
			}
			return minI;
		}

		private void PrintM()
		{
			Console.WriteLine("Matrix M:");
			for (int i = 0; i < M.Count(); i++)
			{
				for (int j = 0; j < attr_q; j++)
					Console.Write(M[i][j] + " ");
				Console.WriteLine();
			}
		}

		private void DeleteFromM(int index)
		{
			var buf = M[index];
			M.RemoveAt(index);
			M.Insert(0, buf);
			index = 0;
			for (int i = M.Count() - 1; i >= 0; i--)
			{
				//если все единицы в текущей строке совпадают с единицами в строке с индексом index, то она удаляется
				bool deleteIt = true;
				for (int j = 0; j < attr_q && deleteIt == true; j++)
					if (M[index][j] == 1 && M[i][j] == 0)
						deleteIt = false;
				if (index != i && deleteIt)
					M.RemoveAt(i);
			}
		}

		public void CreateLogic()
		{
			logic = "";
			string temp_logic = "";
			for (int i = 0; i < M.Count(); i++)
			{
				temp_logic = "(";
				for (int j = 0; j < attr_q; j++)
					if (M[i][j] == 1)
						temp_logic += "p" + j + "+";
				temp_logic = temp_logic.Substring(0, temp_logic.Length - 1); //обрезаем последний + или (, если не было 1
				if (temp_logic.Length != 0)
				{
					if (temp_logic.IndexOf('+') == -1)
						temp_logic = temp_logic.Substring(1, temp_logic.Length - 1);
					else
						temp_logic += ")";
					if (i != M.Count - 1)
						temp_logic += "*";
					logic += temp_logic;
				}
			}

			if (logic[logic.Length - 1] == '*')
				logic.Substring(0, logic.Length - 1);

			Console.WriteLine(logic);
		}

		private void MakeClusters()
		{
			List<List<List<int>>> newM = new List<List<List<int>>>();
			for (int i = 0; i < M.Count(); i++)
			{
				newM.Add(new List<List<int>>());
				for (int j = 0; j < attr_q; j++)
					if (M[i][j] == 1)
					{
						newM[i].Add(new List<int>() { j });
					}
			}

			// newM состоит из индексов единиц упрощенной матрицы M
			//заполнение feature
			feature = (func1(newM))[0];

			for (int i = 0; i < feature.Count; i++)
			{
				Console.Write("Тест #" + i + " ");
				for (int j = 0; j < feature[i].Count; j++)
					Console.Write(feature[i][j] + " ");
				Console.WriteLine();
			}
		}

		private List<List<List<int>>> func1(List<List<List<int>>> level)
		{
			if (level.Count == 1) return level;

			List<List<List<int>>> temp1 = new List<List<List<int>>>();

			//попарное раскрытие скобок и устранение дубликатов
			for (int i = 0; i < level.Count / 2; i++)
			{
				temp1.Add(new List<List<int>>());
				int j = 0;
				for (int j1 = 0; j1 < level[i * 2].Count; j1++)
				{
					for (int j2 = 0; j2 < level[i * 2 + 1].Count; j2++)
					{
						temp1[i].Add(new List<int>());
						foreach (var left in level[i * 2][j1])
							temp1[i][j].Add(left);

						foreach (var right in level[i * 2 + 1][j2])
						{
							if (temp1[i][j].IndexOf(right) == -1)
								temp1[i][j].Add(right);
						}
						temp1[i][j].Sort();
						j++;
					}
				}
				//сортируются по количеству элементов
				temp1[i].Sort(delegate (List<int> x, List<int> y)
				{
					if (x.Count == y.Count) return 0;
					else if (x.Count < y.Count) return -1;
					else return 1;
				});
			}
			if (level.Count % 2 == 1)
			{
				temp1.Add(new List<List<int>>(level[level.Count - 1]));
			}

			//свойство поглощения
			for (int i = 0; i < temp1.Count; i++)
			{
				for (int g = 0, maxi = temp1[i].Count; g < maxi; g++)
					for (int j = temp1[i].Count - 1; j >= 0; j--)
						if (j != g && Consist(temp1[i][g], temp1[i][j]))
						{
							temp1[i].RemoveAt(j);
							maxi--;
						}
			}
			return func1(temp1);
		}

		bool Consist(List<int> subList, List<int> mainList)
		{
			foreach (var s in subList)
				if (mainList.IndexOf(s) == -1)
					return false;
			return true;
		}

		private void CalculateWeight()
		{
			weight = new List<double>();
			int sum_q = feature.Count;
			Console.WriteLine("Веса: ");
			for (int i = 0; i < attr_q; i++)
			{
				double temp = 0;
				for (int j = 0; j < sum_q; j++)
					temp += (feature[j].IndexOf(i) == -1 ? 0 : 1);
				temp /= sum_q;
				if (Double.IsNaN(temp))
				{
					Console.Clear();
					Console.WriteLine("!!! Ошибка в данных !!!");
					return;
				}
				else
				{
					weight.Add(temp);
					Console.WriteLine("R" + i + ": " + temp);
				}
			}
		}

		public int FindCluster(int[] obj)
		{
			int result = -1;
			if (obj.Length != attr_q) return -1; //ЕРРОР
			int max_val = -1;

			int[] count = new int[cl_q];

			int this_class = 0, next_class = 0;

			for (int c_class = 0; c_class < cl_q; c_class++)
			{
				count[c_class] = 0;
				this_class = next_class;
				next_class += cl_len[c_class]; //начало индексов следующего класса
				for (int c_subclass = this_class; c_subclass < next_class; c_subclass++)
				{
					for (int f = 0; f < feature.Count; f++)
					{
						bool ok = true;
						for (int g = 0; g < feature[f].Count && ok; g++)
							if (obj[feature[f][g]] != matrix[c_subclass, feature[f][g]])
								ok = false;
						if (ok) count[c_class]++;
					}
				}
				if (count[c_class] > max_val)
				{
					max_val = count[c_class];
					result = c_class;
				}
			}
			return result;
		}
	}
}

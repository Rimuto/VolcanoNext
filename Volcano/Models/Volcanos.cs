using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Volcano.Models
{
    public class Volcanos
    {
        //первичный ключ
       
        public int VulcanosID { get; set; }
        //Имя вулкана
        [Key]
        public string Name { get; set; }
        //координаты
        public int NL { get; set; } //northern latitude (северная широта)
        public int NLM { get; set; }//минуты для северной широты
        public int EL { get; set; } //eastern longitude (восточная долгота)
        public int ELM { get; set; }//минуты для восточной долготы
        //свойства вулкана
        //...
        [Display(Name = "свойство один")]
        public bool P1 { get; set; }
        [Display(Name = "звездные войны")]
        public bool P2 { get; set; }
        [Display(Name = "мама мия")]
        public bool P3 { get; set; }
        [Display(Name = "Аве МАРИЯ!")]
        public bool P4 { get; set; }
        [Display(Name = "Дэус ВУЛЬТ 0!!!")]
        public bool P5 { get; set; }
        [Display(Name = "Дэус ВУЛЬТ 1!!!")]
        public bool P6 { get; set; }
        [Display(Name = "Дэус ВУЛЬТ 2!!!")]
        public bool P7 { get; set; }
        [Display(Name = "Дэус ВУЛЬТ 3!!!")]
        public bool P8 { get; set; }
        public bool P9 { get; set; }
        public bool P10 { get; set; }
        public bool P11 { get; set; }
        public bool P12 { get; set; }
        public bool P13 { get; set; }
        public bool P14 { get; set; }
        public bool P15 { get; set; }
        public bool P16 { get; set; }
        public bool P17 { get; set; }
        public bool P18 { get; set; }
        public bool P19 { get; set; }
        public bool P20 { get; set; }
        public bool P21 { get; set; }
        public bool P22 { get; set; }
        public bool P23 { get; set; }
        public bool P24 { get; set; }
        public bool P25 { get; set; }
        public bool P26 { get; set; }
        public bool P27 { get; set; }
        public bool P28 { get; set; }
        public bool P29 { get; set; }
        public bool P30 { get; set; }
        public bool P31 { get; set; }
        public bool P32 { get; set; }
        public bool P33 { get; set; }
        public bool P34 { get; set; }
        public bool P35 { get; set; }
        public bool P36 { get; set; }
        public bool P37 { get; set; }
        public bool P38 { get; set; }
        public bool P39 { get; set; }
        public bool P40 { get; set; }
        public bool P41 { get; set; }
        public bool P42 { get; set; }
        public bool P43 { get; set; }
        public bool P44 { get; set; }
        public bool P45 { get; set; }
        public bool P46 { get; set; }
        public bool P47 { get; set; }
        public bool P48 { get; set; }
        public bool P49 { get; set; }
        public bool P50 { get; set; }
        public bool P51 { get; set; }
        public bool P52 { get; set; }
        public bool P53 { get; set; }
        public bool P54 { get; set; }
        public bool P55 { get; set; }
        public bool P56 { get; set; }
        public bool P57 { get; set; }
        public bool P58 { get; set; }
        public bool P59 { get; set; }
        public bool P60 { get; set; }
        public bool P61 { get; set; }
        public bool P62 { get; set; }
        public bool P63 { get; set; }
        public bool P64 { get; set; }
        public bool P65 { get; set; }
        public bool P66 { get; set; }
        public bool P67 { get; set; }
        public bool P68 { get; set; }
        public bool P69 { get; set; }
        public bool P70 { get; set; }
        public bool P71 { get; set; }
        public bool P72 { get; set; }
        public bool P73 { get; set; }
        public bool P74 { get; set; }
        public bool P75 { get; set; }
        public bool P76 { get; set; }
        public bool P77 { get; set; }
        public bool P78 { get; set; }
        public bool P79 { get; set; }
        public bool P80 { get; set; }
        public bool P81 { get; set; }
        public bool P82 { get; set; }
        public bool P83 { get; set; }
        public bool P84 { get; set; }
        public bool P85 { get; set; }
        public bool P86 { get; set; }
        public bool P87 { get; set; }
        public bool P88 { get; set; }
        public bool P89 { get; set; }
        public bool P90 { get; set; }
        public bool P91 { get; set; }
        public bool P92 { get; set; }
        public bool P93 { get; set; }
        public bool P94 { get; set; }
        public bool P95 { get; set; }
        public bool P96 { get; set; }
        public bool P97 { get; set; }
        public bool P98 { get; set; }
        public bool P99 { get; set; }
        public bool P100 { get; set; }
        public bool P101 { get; set; }
        public bool P102 { get; set; }
        public bool P103 { get; set; }
        public bool P104 { get; set; }
        public bool P105 { get; set; }
        public bool P106 { get; set; }
        public bool P107 { get; set; }
        public bool P108 { get; set; }
        public bool P109 { get; set; }
        public bool P110 { get; set; }
        public bool P111 { get; set; }
        public bool P112 { get; set; }
        public bool P113 { get; set; }
        public bool P114 { get; set; }
        public bool P115 { get; set; }
        public bool P116 { get; set; }
        public bool P117 { get; set; }
        public bool P118 { get; set; }
        public bool P119 { get; set; }
        public bool P120 { get; set; }
        public bool P121 { get; set; }
        public bool P122 { get; set; }
        public bool P123 { get; set; }
        public bool P124 { get; set; }
        public bool P125 { get; set; }
        public bool P126 { get; set; }
        public bool P127 { get; set; }
        public bool P128 { get; set; }
        public bool P129 { get; set; }
        public bool P130 { get; set; }
        public bool P131 { get; set; }
        public bool P132 { get; set; }
        public bool P133 { get; set; }
        public bool P134 { get; set; }
        public bool P135 { get; set; }

        //public void UpdateVolcano(Volcanos Vulkan)
        //{
        //    ApplicationContext context = new ApplicationContext();

        //    var customer = context.Vulk
        //        // Загрузить покупателя с фамилией "Иванов"
        //        .Where(c => c.Name == Vulkan.Name)
        //        .FirstOrDefault();

        //    // Внести изменения
        //    customer = Vulkan;

        //    // Сохранить изменения
        //    context.SaveChanges();
        //}
    }
}

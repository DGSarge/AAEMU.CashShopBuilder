//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace AAEmu.CashShopAdmin.Core.Objects.Templates
//{
//    class cashShopItemTemplate
//    {
//    }
//}


using System;
using System.Collections.Generic;

namespace AAEmu.CashShopAdmin.Core.Objects.Templates
{
    public class cashShopItemTemplate
    {
        public int Id { get; set; }
        public int uniq_id { get; set; }
        public string cash_name { get; set; }
        public byte main_tab { get; set; }
        public byte sub_tab { get; set; }
        public byte level_min { get; set; }
        public byte level_max { get; set; }
        public int item_template_id { get; set; }
        public byte is_sell { get; set; }
        public byte is_hidden { get; set; }
        public byte limit_type { get; set; }
        public int buy_count { get; set; }
        public byte buy_type { get; set; }
        public int buy_id { get; set; } 
        public string start_date { get; set; }
        public string end_date { get; set; }
        public byte type { get; set; }
        public int price { get; set; }
        public int remain { get; set; }
        public int bonus_type { get; set; }
        public int bouns_count { get; set; }
        public byte cmd_ui { get; set; }
        public int item_count { get; set; }
        public byte select_type { get; set; }
        public byte default_flag { get; set; }
        public byte event_type { get; set; }
        public string event_date { get; set; }
        public int dis_price { get; set; }
    }
}

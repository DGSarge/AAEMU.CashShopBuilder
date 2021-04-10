using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AAEmu.CashShopAdmin.Core.Objects.Templates;
namespace AAEmu.CashShopAdmin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<cashShopItemTemplate> _ShopItems = new List<cashShopItemTemplate>() ;
        Dictionary<string, cashShopItemTemplate> ItemObjectDict = new Dictionary<string, cashShopItemTemplate>();
        public Int32 ID_Count = 21000000;
        public enum FindPosStates
        {
            NewMainTab = 0,
            NewSubTab = 1,
            NewPage = 2,
            MainTabFinish = 3,
            SubTabFinish = 4,
            Initialized = 666

        }
        private uint _state = (uint)FindPosStates.Initialized;
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //TODO Load all of the tiem lines into ram and fill a list of item objects
            //foreach (var item in _ShopItems)
            //{
            //    item.
            //}
            var lineCount = 1;
            var SkipLinesCount = 0;
            //need to check for string above entries 



            foreach (var line in richTextBox1.Lines)
            {
                if (SkipLinesCount != 0 )
                {
                    SkipLinesCount--;
                    goto A;
                }
                
                if (line.Contains("__________________________________________________________________________________________________________________________________________________________________________"))
                {

                    //set state
                    _state = (uint)FindPosStates.NewMainTab;
                    //skip 5 lines so we land on the first line with an item
                    SkipLinesCount = 4;

                }


                if (line.EndsWith("Finish"))
                {
                    _state = (uint)FindPosStates.NewMainTab;
                }



                //------------------------------
                if (line.StartsWith("(20"))
                {
                    //proccess line into _shopitems
                    
                    //strip first char from line '('
                    //textBox1.AppendText(line.Substring(1) + Environment.NewLine);
                    cashShopItemTemplate xItem = new cashShopItemTemplate();
                    //split up line and add to item object
                    var col = line[1..^1].Split(',');
                    xItem.Id = int.Parse(col[0]);
                    xItem.uniq_id = int.Parse(col[1]);
                    xItem.cash_name = col[2].ToString();
                    xItem.main_tab = byte.Parse(col[3]);
                    xItem.sub_tab = byte.Parse(col[4]);
                    xItem.level_min = byte.Parse(col[5]);
                    xItem.level_max = byte.Parse(col[6]);
                    xItem.item_template_id = int.Parse(col[7]);
                    xItem.is_sell = byte.Parse(col[8]);
                    xItem.is_hidden = byte.Parse(col[9]);
                    xItem.limit_type = byte.Parse(col[10]);
                    xItem.buy_count = int.Parse(col[11]);
                    xItem.buy_type = byte.Parse(col[12]);
                    xItem.buy_id = int.Parse(col[13]);
                    xItem.start_date = col[14].Substring(2, col[14].Length -3);    // .Parse((DateTime)col[14]);
                    xItem.end_date = col[15];
                    xItem.type = byte.Parse(col[16]);
                    xItem.price = int.Parse(col[17]);
                    xItem.remain = int.Parse(col[18]);
                    xItem.bonus_type = int.Parse(col[19]);
                    xItem.bouns_count = int.Parse(col[20]);
                    xItem.cmd_ui = byte.Parse(col[21]);
                    xItem.item_count = int.Parse(col[22]);
                    xItem.select_type = byte.Parse(col[23]);
                    xItem.default_flag = byte.Parse(col[24]);
                    xItem.event_type = byte.Parse(col[25]);
                    xItem.event_date = col[26];
                    var xx = col[27];
                    int xs = Convert.ToInt32(xx.Trim(')'));
                  //  MessageBox.Show(xs.ToString());
                   xItem.dis_price = xs;


                    _ShopItems.Add(xItem);
                    // MessageBox.Show("["+SkipLinesCount.ToString()+"] " + line.ToString());
                    
                }

                A:
                lineCount++;
            }
            foreach (var items in _ShopItems)
            {


                //populate tabs and sub tabs
                //maintab 
                if (items.main_tab.ToString() == "1" )
                {
                    //subtabs
                    if (items.sub_tab.ToString() == "1")
                    {
                        //treeView1.TopNode = 

                        //build string
                        string BuiltItem = items.cash_name  + Environment.NewLine;

                        //add to list
                        listBox1.Items.Add(BuiltItem);
                        //Add to dictionary for later work
                        ItemObjectDict.Add(items.cash_name, items);
                        //textBox1.AppendText("[Name: " + items.cash_name + "]"  + " [Item ID:" + items.item_template_id + "] " + Environment.NewLine);
                    }
                    else if (items.sub_tab.ToString() == "2") //subtab 2 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;

                        //add to list
                        listBox2.Items.Add(BuiltItem);

                        //Add to dictionary for later work
                        ItemObjectDict.Add(items.cash_name, items);
                    }
                    else if (items.sub_tab.ToString() == "3") //subtab 3 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;

                        //add to list
                        listBox3.Items.Add(BuiltItem);

                        //Add to dictionary for later work
                        ItemObjectDict.Add(items.cash_name, items);
                    }
                    else if (items.sub_tab.ToString() == "4") //subtab 4 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;

                        //add to list
                        listBox4.Items.Add(BuiltItem);

                        //Add to dictionary for later work
                        ItemObjectDict.Add(items.cash_name, items);
                    }
                    else if (items.sub_tab.ToString() == "5") //subtab 5 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;

                        //add to list
                        listBox5.Items.Add(BuiltItem);

                        //Add to dictionary for later work
                        ItemObjectDict.Add(items.cash_name, items);
                    }
                    else if (items.sub_tab.ToString() == "6") //subtab 6 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;

                        //add to list
                        listBox6.Items.Add(BuiltItem);

                        //Add to dictionary for later work
                        ItemObjectDict.Add(items.cash_name, items);
                    }
                    else if (items.sub_tab.ToString() == "7") //subtab 7 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;

                        //add to list
                        listBox7.Items.Add(BuiltItem);

                        //Add to dictionary for later work
                        ItemObjectDict.Add(items.cash_name, items);
                    }
                }// MAIN TAB END 
                //BEGIN GENERAL TAB
                if (items.main_tab.ToString() == "2")
                {
                    //subtabs
                    if (items.sub_tab.ToString() == "1")
                    {
                        //treeView1.TopNode = 

                        //build string
                        string BuiltItem = items.cash_name + Environment.NewLine;

                   
                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);
                            //add to list
                            listBox8.Items.Add(BuiltItem);
                        }
                      
                        //textBox1.AppendText("[Name: " + items.cash_name + "]"  + " [Item ID:" + items.item_template_id + "] " + Environment.NewLine);
                    }
                    else if (items.sub_tab.ToString() == "2") //subtab 2 of 7
                    {

                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;


                     
                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);
                            //add to list
                            listBox9.Items.Add(BuiltItem);
                        }


                        
                       
                    }
                    else if (items.sub_tab.ToString() == "3") //subtab 3 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;

                       

                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);
                            //add to list
                            listBox10.Items.Add(BuiltItem);
                        }
                    }
                    else if (items.sub_tab.ToString() == "4") //subtab 4 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;

                      

                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);
                            //add to list
                            listBox11.Items.Add(BuiltItem);
                        }
                    }
                    else if (items.sub_tab.ToString() == "5") //subtab 5 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;


                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);

                            //add to list
                            listBox12.Items.Add(BuiltItem);
                        }
                    }
                    else if (items.sub_tab.ToString() == "6") //subtab 6 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;

                      

                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);
                            //add to list
                            listBox13.Items.Add(BuiltItem);
                        }
                    }
                    else if (items.sub_tab.ToString() == "7") //subtab 7 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;

                      

                        //Add to dictionary for later work
                       if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);
                            //add to list
                            listBox14.Items.Add(BuiltItem);
                        }
                    }
                }
                // MAIN TAB END 
                //BEGIN Travel TAB
                if (items.main_tab.ToString() == "3")
                {
                    //subtabs
                    if (items.sub_tab.ToString() == "1")
                    {
                        //treeView1.TopNode = 

                        //build string
                        string BuiltItem = items.cash_name + Environment.NewLine;


                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);
                            //add to list
                            listBox15.Items.Add(BuiltItem);
                        }

                        //textBox1.AppendText("[Name: " + items.cash_name + "]"  + " [Item ID:" + items.item_template_id + "] " + Environment.NewLine);
                    }
                    else if (items.sub_tab.ToString() == "2") //subtab 2 of 7
                    {

                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;



                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);
                            //add to list
                            listBox16.Items.Add(BuiltItem);
                        }




                    }
                    else if (items.sub_tab.ToString() == "3") //subtab 3 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;



                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);
                            //add to list
                            listBox17.Items.Add(BuiltItem);
                        }
                    }
                    else if (items.sub_tab.ToString() == "4") //subtab 4 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;



                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);
                            //add to list
                            listBox18.Items.Add(BuiltItem);
                        }
                    }
                    else if (items.sub_tab.ToString() == "5") //subtab 5 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;


                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);

                            //add to list
                            listBox19.Items.Add(BuiltItem);
                        }
                    }
                    else if (items.sub_tab.ToString() == "6") //subtab 6 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;



                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);
                            //add to list
                            listBox20.Items.Add(BuiltItem);
                        }
                    }
                    else if (items.sub_tab.ToString() == "7") //subtab 7 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;



                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);
                            //add to list
                            listBox21.Items.Add(BuiltItem);
                        }
                    }
                }
                //BEGIN land TAB
                if (items.main_tab.ToString() == "4")
                {
                    //subtabs
                    if (items.sub_tab.ToString() == "1")
                    {
                        //treeView1.TopNode = 

                        //build string
                        string BuiltItem = items.cash_name + Environment.NewLine;


                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);
                            //add to list
                            listBox22.Items.Add(BuiltItem);
                        }

                        //textBox1.AppendText("[Name: " + items.cash_name + "]"  + " [Item ID:" + items.item_template_id + "] " + Environment.NewLine);
                    }
                    else if (items.sub_tab.ToString() == "2") //subtab 2 of 7
                    {

                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;



                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);
                            //add to list
                            listBox23.Items.Add(BuiltItem);
                        }




                    }
                    else if (items.sub_tab.ToString() == "3") //subtab 3 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;



                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);
                            //add to list
                            listBox24.Items.Add(BuiltItem);
                        }
                    }
                    else if (items.sub_tab.ToString() == "4") //subtab 4 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;



                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);
                            //add to list
                            listBox25.Items.Add(BuiltItem);
                        }
                    }
                    else if (items.sub_tab.ToString() == "5") //subtab 5 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;


                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);

                            //add to list
                            listBox26.Items.Add(BuiltItem);
                        }
                    }
                    else if (items.sub_tab.ToString() == "6") //subtab 6 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;



                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);
                            //add to list
                            listBox27.Items.Add(BuiltItem);
                        }
                    }
                    else if (items.sub_tab.ToString() == "7") //subtab 7 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;



                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);
                            //add to list
                            listBox28.Items.Add(BuiltItem);
                        }
                    }
                }
                //BEGIN Custom TAB
                if (items.main_tab.ToString() == "5")
                {
                    //subtabs
                    if (items.sub_tab.ToString() == "1")
                    {
                        //treeView1.TopNode = 

                        //build string
                        string BuiltItem = items.cash_name + Environment.NewLine;


                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);
                            //add to list
                            listBox29.Items.Add(BuiltItem);
                        }

                        //textBox1.AppendText("[Name: " + items.cash_name + "]"  + " [Item ID:" + items.item_template_id + "] " + Environment.NewLine);
                    }
                    else if (items.sub_tab.ToString() == "2") //subtab 2 of 7
                    {

                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;



                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);
                            //add to list
                            listBox30.Items.Add(BuiltItem);
                        }




                    }
                    else if (items.sub_tab.ToString() == "3") //subtab 3 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;



                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);
                            //add to list
                            listBox31.Items.Add(BuiltItem);
                        }
                    }
                    else if (items.sub_tab.ToString() == "4") //subtab 4 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;



                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);
                            //add to list
                            listBox32.Items.Add(BuiltItem);
                        }
                    }
                    else if (items.sub_tab.ToString() == "5") //subtab 5 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;


                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);

                            //add to list
                            listBox33.Items.Add(BuiltItem);
                        }
                    }
                    else if (items.sub_tab.ToString() == "6") //subtab 6 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;



                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);
                            //add to list
                            listBox34.Items.Add(BuiltItem);
                        }
                    }
                    else if (items.sub_tab.ToString() == "7") //subtab 7 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;



                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);
                            //add to list
                            listBox35.Items.Add(BuiltItem);
                        }
                    }
                }
                //BEGIN Loyalty TAB
                if (items.main_tab.ToString() == "6")
                {
                    //subtabs
                    if (items.sub_tab.ToString() == "1")
                    {
                        //treeView1.TopNode = 

                        //build string
                        string BuiltItem = items.cash_name + Environment.NewLine;


                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);
                            //add to list
                            listBox36.Items.Add(BuiltItem);
                        }

                        //textBox1.AppendText("[Name: " + items.cash_name + "]"  + " [Item ID:" + items.item_template_id + "] " + Environment.NewLine);
                    }
                    else if (items.sub_tab.ToString() == "2") //subtab 2 of 7
                    {

                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;



                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);
                            //add to list
                            listBox37.Items.Add(BuiltItem);
                        }




                    }
                    else if (items.sub_tab.ToString() == "3") //subtab 3 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;



                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);
                            //add to list
                            listBox38.Items.Add(BuiltItem);
                        }
                    }
                    else if (items.sub_tab.ToString() == "4") //subtab 4 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;



                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);
                            //add to list
                            listBox39.Items.Add(BuiltItem);
                        }
                    }
                    else if (items.sub_tab.ToString() == "5") //subtab 5 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;


                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);

                            //add to list
                            listBox40.Items.Add(BuiltItem);
                        }
                    }
                    else if (items.sub_tab.ToString() == "6") //subtab 6 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;



                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);
                            //add to list
                            listBox41.Items.Add(BuiltItem);
                        }
                    }
                    else if (items.sub_tab.ToString() == "7") //subtab 7 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;



                        //Add to dictionary for later work
                        if (ItemObjectDict.ContainsKey(items.cash_name) == false)
                        {
                            ItemObjectDict.Add(items.cash_name, items);
                            //add to list
                            listBox42.Items.Add(BuiltItem);
                        }
                    }
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
        public void DelFrmTbl(ListBox listBox) 
        {
            // Remove from Objects list
            foreach (var obj in _ShopItems)
            {
                if (listBox.GetItemText(listBox.SelectedItem).Contains(obj.cash_name))
                {
                    MessageBox.Show("DelFrmTbl |:| Removed: " + obj.cash_name);
                    _ShopItems.Remove(obj);
                    goto B;
                }
            }

        B:
            //Remove From WOrkingList Dictionary
            ItemObjectDict.Remove(listBox1.GetItemText(listBox1.SelectedItem));

            //Finally Remove from List
            listBox.Items.RemoveAt(listBox.SelectedIndex);
        }
        private void button1_Click(object sender, EventArgs e)
        {


            DelFrmTbl(listBox1);

        //    // Remove from Objects list
        //    foreach (var obj  in _ShopItems)
        //    {
        //        if (listBox1.GetItemText(listBox1.SelectedItem).Contains(obj.cash_name))
        //        {
        //            MessageBox.Show("Removed: " + obj.cash_name);
        //            _ShopItems.Remove(obj);
        //            goto B;
        //        }
        //    }

        //B:
        //    //Remove From WOrkingList Dictionary
        //    ItemObjectDict.Remove(listBox1.GetItemText(listBox1.SelectedItem));
           
        //    //Finally Remove from List
        //    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox2);
            //    // Remove from Objects list
            //    foreach (var obj in _ShopItems)
            //    {
            //        if (listBox2.GetItemText(listBox2.SelectedItem).Contains(obj.cash_name))
            //        {
            //            MessageBox.Show("Removed: " + obj.cash_name);
            //            _ShopItems.Remove(obj);
            //            goto B2;
            //        }
            //    }

            //B2:
            //    //Remove From WOrkingList Dictionary
            //    ItemObjectDict.Remove(listBox2.GetItemText(listBox2.SelectedItem));



            //    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox3);
            //    // Remove from Objects list
            //    foreach (var obj in _ShopItems)
            //    {
            //        if (listBox3.GetItemText(listBox3.SelectedItem).Contains(obj.cash_name))
            //        {
            //            MessageBox.Show("Removed: " + obj.cash_name);
            //            _ShopItems.Remove(obj);
            //            goto B3;
            //        }
            //    }

            //B3:
            //    //Remove From WOrkingList Dictionary
            //    ItemObjectDict.Remove(listBox3.GetItemText(listBox3.SelectedItem));


            //    listBox3.Items.RemoveAt(listBox3.SelectedIndex);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox5);
        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox6);
        }

        private void tabPage9_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {


            DelFrmTbl(listBox7);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button8_Click(object sender, EventArgs e)
        {
            // AddItem(string itemName, string itemID, string price, string stock, string discount, string minLVL, string maxLVL, string mainTab, string subTab)
            AddItem(textBox1.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, comboBox1.GetItemText(comboBox1.SelectedItem), comboBox2.GetItemText(comboBox2.SelectedItem), "1", "1", listBox1);


        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            // AddItem(string itemName, string itemID, string price, string stock, string discount, string minLVL, string maxLVL, string mainTab, string subTab)
            AddItem(textBox11.Text, textBox10.Text, textBox9.Text, textBox8.Text, textBox7.Text, comboBox4.GetItemText(comboBox4.SelectedItem), comboBox3.GetItemText(comboBox3.SelectedItem), "1", "2", listBox2);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            // AddItem(string itemName, string itemID, string price, string stock, string discount, string minLVL, string maxLVL, string mainTab, string subTab)
            AddItem(textBox16.Text, textBox15.Text, textBox14.Text, textBox13.Text, textBox12.Text, comboBox6.GetItemText(comboBox6.SelectedItem), comboBox5.GetItemText(comboBox5.SelectedItem), "1", "3", listBox3);

        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

             AddItem(textBox21.Text, textBox20.Text, textBox19.Text, textBox18.Text, textBox17.Text, comboBox8.GetItemText(comboBox8.SelectedItem), comboBox7.GetItemText(comboBox7.SelectedItem), "1", "4", listBox4);
         
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

            AddItem(textBox26.Text, textBox25.Text, textBox24.Text, textBox23.Text, textBox22.Text, comboBox10.GetItemText(comboBox10.SelectedItem), comboBox9.GetItemText(comboBox9.SelectedItem), "1", "5", listBox5);

        }

        private void button13_Click(object sender, EventArgs e)
        {

             AddItem(textBox31.Text, textBox30.Text, textBox29.Text, textBox28.Text, textBox27.Text, comboBox12.GetItemText(comboBox12.SelectedItem), comboBox11.GetItemText(comboBox11.SelectedItem), "1", "6", listBox6);

        }

        private void button14_Click(object sender, EventArgs e)
        {
             AddItem(textBox36.Text, textBox35.Text, textBox34.Text, textBox33.Text, textBox32.Text, comboBox14.GetItemText(comboBox14.SelectedItem), comboBox13.GetItemText(comboBox13.SelectedItem), "1", "7", listBox7);

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            //MAINTAB/2

            DelFrmTbl(listBox8);
        }
            private void button18_Click(object sender, EventArgs e)
        {
                //MAINTAB/2

                DelFrmTbl(listBox9);
            }

        private void button20_Click(object sender, EventArgs e)
        {
                //MAINTAB/2

                // Remove from Objects list
                DelFrmTbl(listBox10);
            }

        private void button22_Click(object sender, EventArgs e)
        {
                //MAINTAB/2

                DelFrmTbl(listBox11);
            }

        private void button24_Click(object sender, EventArgs e)
        {
                //MAINTAB/2

                // Remove from Objects list
                DelFrmTbl(listBox12);
            }

        private void button26_Click(object sender, EventArgs e)
        {
                //MAINTAB/2

                DelFrmTbl(listBox13);
            }

        private void tabControl3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {
                //MAINTAB/2

                DelFrmTbl(listBox14);
            }

        private void button15_Click(object sender, EventArgs e)
        {
            // AddItem(string itemName, string itemID, string price, string stock, string discount, string minLVL, string maxLVL, string mainTab, string subTab)
            AddItem(textBox41.Text, textBox40.Text, textBox39.Text, textBox38.Text,
                    textBox37.Text, comboBox15.GetItemText(comboBox15.SelectedItem),
                    comboBox16.GetItemText(comboBox16.SelectedItem), "2", "1", listBox8);
          
        }

        private void button17_Click(object sender, EventArgs e)
        {
            AddItem(textBox46.Text, textBox45.Text, textBox43.Text, textBox44.Text, textBox42.Text, comboBox17.GetItemText(comboBox17.SelectedItem), comboBox18.GetItemText(comboBox18.SelectedItem), "2", "2", listBox9);
            
         
        }

        private void textBox45_TextChanged(object sender, EventArgs e)
        {

        }


        public void AddItem(string itemName, string itemID, string price,
                            string stock, string discount, string minLVL,
                            string maxLVL, string mainTab, string subTab,
                            ListBox tabListbox) 
        {

            //MainTab/2

            cashShopItemTemplate xItem = new cashShopItemTemplate();
            //split up line and add to item object


            //sequential
            xItem.Id = ID_Count;
            ID_Count++;

            //randomGen
            var num = new Random();
            xItem.uniq_id = num.Next(77770000);

            xItem.cash_name = itemName;


            // check for main tab and set 
            var maintab = tabControl1.SelectedTab.Text;
            var subtab = tabControl2.SelectedTab.Text;
            //hard coding all tabs becuase fuck nesting an if 20 sumthing times
            xItem.main_tab = byte.Parse(mainTab);
            //hard coding all tabs becuase fuck nesting an if 20 sumthing times
            xItem.sub_tab = byte.Parse(subTab);

            xItem.level_min = byte.Parse(minLVL);
            xItem.level_max = byte.Parse(maxLVL);

            xItem.item_template_id = int.Parse(itemID);//idtxtbox


            xItem.is_sell = byte.Parse("0");
            xItem.is_hidden = byte.Parse("0");
            xItem.limit_type = byte.Parse("0");
            xItem.buy_count = int.Parse("0");
            xItem.buy_type = byte.Parse("0");
            xItem.buy_id = int.Parse("0");

            //hardcoded for now , future plans for UI date time picker
            xItem.start_date = "2021-01-01 14:10:08";    // .Parse((DateTime)col[14]);
            xItem.end_date = "2055-06-16 14:10:12";

            xItem.type = byte.Parse("0");
            xItem.price = int.Parse(price);
            xItem.remain = int.Parse(stock);

            xItem.bonus_type = int.Parse("0");
            xItem.bouns_count = int.Parse("0");
            xItem.cmd_ui = byte.Parse("0");
            xItem.item_count = int.Parse("0");
            xItem.select_type = byte.Parse("0");
            xItem.default_flag = byte.Parse("0");
            xItem.event_type = byte.Parse("0");
            xItem.event_date = "0001-01-01 00:00:00";
            xItem.dis_price = int.Parse(discount);
       //add item to list, dict and listbox needs checks for dups
            if (_ShopItems.Contains(xItem) == false)
            {
                _ShopItems.Add(xItem);
            }
            else
            {
                MessageBox.Show("Error: " + xItem.cash_name + " already in List");
            }
            //_ShopItems.Add(xItem);
            if (ItemObjectDict.ContainsKey(xItem.cash_name) == false)
            {
                ItemObjectDict.Add(xItem.cash_name, xItem);
            }
            else
            {
                MessageBox.Show("Error: " + xItem.cash_name + " already in Dictionary");
            }
            //ItemObjectDict.Add(xItem.cash_name, xItem);

            //OVERSIGHT ADD ARGUMENT PASS LISTBOX NAME TO IT AND ADD Code Here - im a dumbass discoverd this 3 main tabs in
            if (tabListbox.Items.Contains(xItem.cash_name) == false)
            {
                tabListbox.Items.Add(xItem.cash_name);
            }
            else
            {
                MessageBox.Show("Error: " + xItem.cash_name + " already in ListBox");

            }
            //listBox3.Items.Add(xItem.cash_name);

            ////add item to list, dict and listbox
            //_ShopItems.Add(xItem);
            //ItemObjectDict.Add(xItem.cash_name, xItem);
            //listBox1.Items.Add(xItem.cash_name);

        }

        private void button19_Click(object sender, EventArgs e)
        {
            AddItem(textBox51.Text, textBox50.Text, textBox49.Text, textBox48.Text, textBox47.Text, comboBox20.GetItemText(comboBox20.SelectedItem), comboBox19.GetItemText(comboBox19.SelectedItem), "2", "3", listBox10);
        }

        private void groupBox12_Enter(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            AddItem(textBox56.Text, textBox55.Text, textBox54.Text, textBox53.Text, textBox52.Text, comboBox22.GetItemText(comboBox22.SelectedItem), comboBox21.GetItemText(comboBox21.SelectedItem), "2", "4", listBox11);
        }

        private void groupBox13_Enter(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {
            AddItem(textBox61.Text, textBox60.Text, textBox59.Text, textBox58.Text, textBox57.Text, comboBox24.GetItemText(comboBox24.SelectedItem), comboBox23.GetItemText(comboBox23.SelectedItem), "2", "5", listBox12);

        }

        private void button25_Click(object sender, EventArgs e)
        {
            AddItem(textBox62.Text, textBox61.Text, textBox60.Text, textBox59.Text, textBox58.Text, comboBox22.GetItemText(comboBox22.SelectedItem), comboBox21.GetItemText(comboBox21.SelectedItem), "2", "6", listBox13);

        }

        private void button30_Click(object sender, EventArgs e)
        {
            //MAINTAB/3

            DelFrmTbl(listBox15);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox16);
        }

        private void button34_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox17);
        }

        private void button36_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox18);
        }

        private void button38_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox19);
        }

        private void button40_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox20);
        }

        private void button42_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox21);
        }

        private void button41_Click(object sender, EventArgs e)
        {
            AddItem(textBox106.Text, textBox105.Text, textBox104.Text, textBox103.Text,
                    textBox102.Text, comboBox42.GetItemText(comboBox42.SelectedItem),
                    comboBox41.GetItemText(comboBox41.SelectedItem), "3", "7", listBox21);
        }

        private void tabControl4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button29_Click(object sender, EventArgs e)
        {
            AddItem(textBox76.Text, textBox75.Text, textBox74.Text, textBox73.Text,
                   textBox72.Text, comboBox30.GetItemText(comboBox30.SelectedItem),
                   comboBox29.GetItemText(comboBox29.SelectedItem), "3", "1", listBox15);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            AddItem(textBox81.Text, textBox80.Text, textBox79.Text, textBox78.Text,
                  textBox77.Text, comboBox32.GetItemText(comboBox32.SelectedItem),
                  comboBox31.GetItemText(comboBox31.SelectedItem), "3", "2", listBox16);
        }

        private void groupBox18_Enter(object sender, EventArgs e)
        {

        }

        private void button33_Click(object sender, EventArgs e)
        {
            AddItem(textBox86.Text, textBox85.Text, textBox84.Text, textBox83.Text,
               textBox82.Text, comboBox34.GetItemText(comboBox34.SelectedItem),
               comboBox33.GetItemText(comboBox33.SelectedItem), "3", "3", listBox17);
        }

        private void groupBox19_Enter(object sender, EventArgs e)
        {

        }

        private void button35_Click(object sender, EventArgs e)
        {
            AddItem(textBox91.Text, textBox90.Text, textBox89.Text, textBox88.Text,
              textBox87.Text, comboBox36.GetItemText(comboBox36.SelectedItem),
              comboBox35.GetItemText(comboBox35.SelectedItem), "3", "4", listBox18);//
        }

        private void groupBox20_Enter(object sender, EventArgs e)
        {

        }

        private void button37_Click(object sender, EventArgs e)
        {
            AddItem(textBox96.Text, textBox95.Text, textBox94.Text, textBox93.Text,
            textBox92.Text, comboBox38.GetItemText(comboBox38.SelectedItem),
            comboBox37.GetItemText(comboBox37.SelectedItem), "3", "5", listBox19);//
        }

        private void button39_Click(object sender, EventArgs e)
        {
            AddItem(textBox101.Text, textBox100.Text, textBox99.Text, textBox98.Text,
         textBox97.Text, comboBox40.GetItemText(comboBox40.SelectedItem),
         comboBox39.GetItemText(comboBox39.SelectedItem), "3", "6", listBox20);//
        }

        private void groupBox15_Enter(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {
            AddItem(textBox71.Text, textBox70.Text, textBox69.Text, textBox68.Text,
                    textBox67.Text, comboBox28.GetItemText(comboBox28.SelectedItem),
                    comboBox27.GetItemText(comboBox27.SelectedItem), "2", "7", listBox14);
        }

        private void button43_Click(object sender, EventArgs e)
        {
            AddItem(textBox111.Text, textBox110.Text, textBox109.Text, textBox108.Text,
                    textBox107.Text, comboBox44.GetItemText(comboBox44.SelectedItem),
                    comboBox43.GetItemText(comboBox43.SelectedItem), "4", "1", listBox22);
        }

        private void button44_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox22);
        }

        private void button45_Click(object sender, EventArgs e)
        {
            AddItem(textBox116.Text, textBox115.Text, textBox114.Text, textBox113.Text,
                   textBox112.Text, comboBox46.GetItemText(comboBox46.SelectedItem),
                   comboBox45.GetItemText(comboBox45.SelectedItem), "4", "2", listBox23);
        }

        private void button46_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox23);
        }

        private void button47_Click(object sender, EventArgs e)
        {
            AddItem(textBox121.Text, textBox120.Text, textBox119.Text, textBox118.Text,
                    textBox117.Text, comboBox48.GetItemText(comboBox48.SelectedItem),
                    comboBox47.GetItemText(comboBox47.SelectedItem), "4", "3", listBox24);
        }

        private void button48_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox24);
        }

        private void button49_Click(object sender, EventArgs e)
        {
            AddItem(textBox126.Text, textBox125.Text, textBox124.Text, textBox123.Text,
                 textBox122.Text, comboBox50.GetItemText(comboBox50.SelectedItem),
                 comboBox49.GetItemText(comboBox49.SelectedItem), "4", "4", listBox25);
        }

        private void button50_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox25);
        }

        private void button51_Click(object sender, EventArgs e)
        {
            AddItem(textBox131.Text, textBox130.Text, textBox129.Text, textBox128.Text,
                textBox127.Text, comboBox52.GetItemText(comboBox52.SelectedItem),
                comboBox51.GetItemText(comboBox51.SelectedItem), "4", "5", listBox26);
        }

        private void button52_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox26);
        }

        private void tabControl5_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddItem(textBox136.Text, textBox135.Text, textBox134.Text, textBox133.Text,
              textBox132.Text, comboBox54.GetItemText(comboBox54.SelectedItem),
              comboBox53.GetItemText(comboBox53.SelectedItem), "4", "6", listBox27);
        }

        private void button54_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox27);
        }

        private void button55_Click(object sender, EventArgs e)
        {
            AddItem(textBox141.Text, textBox140.Text, textBox139.Text, textBox138.Text,
           textBox137.Text, comboBox56.GetItemText(comboBox56.SelectedItem),
           comboBox55.GetItemText(comboBox55.SelectedItem), "4", "7", listBox28);
        }

        private void button56_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox28);
        }

        private void button57_Click(object sender, EventArgs e)
        {
            AddItem(textBox146.Text, textBox145.Text, textBox144.Text, textBox143.Text,
         textBox142.Text, comboBox58.GetItemText(comboBox58.SelectedItem),
         comboBox57.GetItemText(comboBox57.SelectedItem), "5", "1", listBox29);
        }

        private void button58_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox29);
        }

        private void button59_Click(object sender, EventArgs e)
        {
            AddItem(textBox151.Text, textBox150.Text, textBox149.Text, textBox148.Text,
         textBox147.Text, comboBox60.GetItemText(comboBox60.SelectedItem),
         comboBox59.GetItemText(comboBox59.SelectedItem), "5", "2", listBox30);
        }

        private void button60_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox30);
        }

        private void button61_Click(object sender, EventArgs e)
        {
            AddItem(textBox156.Text, textBox155.Text, textBox154.Text, textBox153.Text,
         textBox152.Text, comboBox62.GetItemText(comboBox62.SelectedItem),
         comboBox61.GetItemText(comboBox61.SelectedItem), "5", "3", listBox31);
        }

        private void button62_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox31);
        }

        private void button63_Click(object sender, EventArgs e)
        {
            AddItem(textBox161.Text, textBox160.Text, textBox159.Text, textBox158.Text,
        textBox157.Text, comboBox64.GetItemText(comboBox64.SelectedItem),
        comboBox63.GetItemText(comboBox63.SelectedItem), "5", "4", listBox32);
        }

        private void button64_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox32);
        }

        private void button65_Click(object sender, EventArgs e)
        {
            AddItem(textBox166.Text, textBox165.Text, textBox164.Text, textBox163.Text,
   textBox162.Text, comboBox66.GetItemText(comboBox66.SelectedItem),
   comboBox65.GetItemText(comboBox65.SelectedItem), "5", "5", listBox33);
        }

        private void button66_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox33);
        }

        private void button67_Click(object sender, EventArgs e)
        {
            AddItem(textBox171.Text, textBox170.Text, textBox169.Text, textBox168.Text,
                    textBox167.Text, comboBox68.GetItemText(comboBox68.SelectedItem),
                    comboBox67.GetItemText(comboBox67.SelectedItem), "5", "6", listBox34);
        }

        private void button68_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox34);
        }

        private void button69_Click(object sender, EventArgs e)
        {
            AddItem(textBox176.Text, textBox175.Text, textBox174.Text, textBox173.Text,
                  textBox172.Text, comboBox70.GetItemText(comboBox70.SelectedItem),
                  comboBox69.GetItemText(comboBox69.SelectedItem), "5", "7", listBox35);
        }

        private void button70_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox35);
        }

        private void tabControl6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button71_Click(object sender, EventArgs e)
        {
            AddItem(textBox181.Text, textBox180.Text, textBox179.Text, textBox178.Text,
                 textBox177.Text, comboBox72.GetItemText(comboBox72.SelectedItem),
                 comboBox71.GetItemText(comboBox71.SelectedItem), "6", "1", listBox36);
        }

        private void button72_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox36);
        }

        private void button73_Click(object sender, EventArgs e)
        {
            AddItem(textBox186.Text, textBox185.Text, textBox184.Text, textBox183.Text,
                textBox182.Text, comboBox74.GetItemText(comboBox74.SelectedItem),
                comboBox73.GetItemText(comboBox73.SelectedItem), "6", "2", listBox37);
        }

        private void button74_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox37);
        }

        private void button75_Click(object sender, EventArgs e)
        {
            AddItem(textBox191.Text, textBox190.Text, textBox189.Text, textBox188.Text,
                textBox187.Text, comboBox76.GetItemText(comboBox76.SelectedItem),
                comboBox75.GetItemText(comboBox75.SelectedItem), "6", "3", listBox38);
        }

        private void button76_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox38);
        }

        private void button77_Click(object sender, EventArgs e)
        {
            AddItem(textBox196.Text, textBox195.Text, textBox194.Text, textBox193.Text,
              textBox192.Text, comboBox78.GetItemText(comboBox78.SelectedItem),
              comboBox77.GetItemText(comboBox77.SelectedItem), "6", "4", listBox39);
        }

        private void button78_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox39);
        }

        private void button79_Click(object sender, EventArgs e)
        {
            AddItem(textBox201.Text, textBox200.Text, textBox199.Text, textBox198.Text,
             textBox197.Text, comboBox80.GetItemText(comboBox80.SelectedItem),
             comboBox79.GetItemText(comboBox79.SelectedItem), "6", "5", listBox40);
        }

        private void button80_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox40);
        }

        private void groupBox42_Enter(object sender, EventArgs e)
        {

        }

        private void button81_Click(object sender, EventArgs e)
        {
            AddItem(textBox206.Text, textBox205.Text, textBox204.Text, textBox203.Text,
            textBox202.Text, comboBox82.GetItemText(comboBox82.SelectedItem),
            comboBox81.GetItemText(comboBox81.SelectedItem), "6", "6", listBox41);
        }

        private void button82_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox41);
        }

        private void button83_Click(object sender, EventArgs e)
        {
            AddItem(textBox211.Text, textBox210.Text, textBox209.Text, textBox208.Text,
           textBox207.Text, comboBox84.GetItemText(comboBox84.SelectedItem),
           comboBox83.GetItemText(comboBox83.SelectedItem), "6", "7", listBox42);
        }

        private void button84_Click(object sender, EventArgs e)
        {
            DelFrmTbl(listBox42);
        }
    }
}

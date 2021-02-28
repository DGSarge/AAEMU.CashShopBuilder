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
        Dictionary<string, cashShopItemTemplate> WorkingItemsList = new Dictionary<string, cashShopItemTemplate>();
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
                        WorkingItemsList.Add(items.cash_name, items);
                        //textBox1.AppendText("[Name: " + items.cash_name + "]"  + " [Item ID:" + items.item_template_id + "] " + Environment.NewLine);
                    }
                    else if (items.sub_tab.ToString() == "2") //subtab 2 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;

                        //add to list
                        listBox2.Items.Add(BuiltItem);

                        //Add to dictionary for later work
                        WorkingItemsList.Add(items.cash_name, items);
                    }
                    else if (items.sub_tab.ToString() == "3") //subtab 3 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;

                        //add to list
                        listBox3.Items.Add(BuiltItem);

                        //Add to dictionary for later work
                        WorkingItemsList.Add(items.cash_name, items);
                    }
                    else if (items.sub_tab.ToString() == "4") //subtab 4 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;

                        //add to list
                        listBox4.Items.Add(BuiltItem);

                        //Add to dictionary for later work
                        WorkingItemsList.Add(items.cash_name, items);
                    }
                    else if (items.sub_tab.ToString() == "5") //subtab 5 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;

                        //add to list
                        listBox5.Items.Add(BuiltItem);

                        //Add to dictionary for later work
                        WorkingItemsList.Add(items.cash_name, items);
                    }
                    else if (items.sub_tab.ToString() == "6") //subtab 6 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;

                        //add to list
                        listBox6.Items.Add(BuiltItem);

                        //Add to dictionary for later work
                        WorkingItemsList.Add(items.cash_name, items);
                    }
                    else if (items.sub_tab.ToString() == "7") //subtab 7 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;

                        //add to list
                        listBox7.Items.Add(BuiltItem);

                        //Add to dictionary for later work
                        WorkingItemsList.Add(items.cash_name, items);
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
                        if (WorkingItemsList.ContainsKey(items.cash_name) == false)
                        {
                            WorkingItemsList.Add(items.cash_name, items);
                            //add to list
                            listBox8.Items.Add(BuiltItem);
                        }
                      
                        //textBox1.AppendText("[Name: " + items.cash_name + "]"  + " [Item ID:" + items.item_template_id + "] " + Environment.NewLine);
                    }
                    else if (items.sub_tab.ToString() == "2") //subtab 2 of 7
                    {

                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;


                        //add to list
                        listBox9.Items.Add(BuiltItem);
                        //Add to dictionary for later work
                        if (WorkingItemsList.ContainsKey(items.cash_name) == false)
                        {
                            WorkingItemsList.Add(items.cash_name, items);
                        }


                        
                       
                    }
                    else if (items.sub_tab.ToString() == "3") //subtab 3 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;

                        //add to list
                        listBox10.Items.Add(BuiltItem);

                        //Add to dictionary for later work
                        if (WorkingItemsList.ContainsKey(items.cash_name) == false)
                        {
                            WorkingItemsList.Add(items.cash_name, items);
                        }
                    }
                    else if (items.sub_tab.ToString() == "4") //subtab 4 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;

                        //add to list
                        listBox11.Items.Add(BuiltItem);

                        //Add to dictionary for later work
                        if (WorkingItemsList.ContainsKey(items.cash_name) == false)
                        {
                            WorkingItemsList.Add(items.cash_name, items);
                        }
                    }
                    else if (items.sub_tab.ToString() == "5") //subtab 5 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;

                        //add to list
                        listBox12.Items.Add(BuiltItem);

                        //Add to dictionary for later work
                        if (WorkingItemsList.ContainsKey(items.cash_name) == false)
                        {
                            WorkingItemsList.Add(items.cash_name, items);
                        }
                    }
                    else if (items.sub_tab.ToString() == "6") //subtab 6 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;

                        //add to list
                        listBox13.Items.Add(BuiltItem);

                        //Add to dictionary for later work
                        if (WorkingItemsList.ContainsKey(items.cash_name) == false)
                        {
                            WorkingItemsList.Add(items.cash_name, items);
                        }
                    }
                    else if (items.sub_tab.ToString() == "7") //subtab 7 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;

                        //add to list
                        listBox14.Items.Add(BuiltItem);

                        //Add to dictionary for later work
                       if (WorkingItemsList.ContainsKey(items.cash_name) == false)
                        {
                            WorkingItemsList.Add(items.cash_name, items);
                        }
                    }
                }

            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Remove from Objects list
            foreach (var obj  in _ShopItems)
            {
                if (listBox1.GetItemText(listBox1.SelectedItem).Contains(obj.cash_name))
                {
                    MessageBox.Show("Removed: " + obj.cash_name);
                    _ShopItems.Remove(obj);
                    goto B;
                }
            }

        B:
            //Remove From WOrkingList Dictionary
            WorkingItemsList.Remove(listBox1.GetItemText(listBox1.SelectedItem));
           
            //Finally Remove from List
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            // Remove from Objects list
            foreach (var obj in _ShopItems)
            {
                if (listBox2.GetItemText(listBox2.SelectedItem).Contains(obj.cash_name))
                {
                    MessageBox.Show("Removed: " + obj.cash_name);
                    _ShopItems.Remove(obj);
                    goto B2;
                }
            }

        B2:
            //Remove From WOrkingList Dictionary
            WorkingItemsList.Remove(listBox2.GetItemText(listBox2.SelectedItem));



            listBox2.Items.RemoveAt(listBox2.SelectedIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Remove from Objects list
            foreach (var obj in _ShopItems)
            {
                if (listBox3.GetItemText(listBox3.SelectedItem).Contains(obj.cash_name))
                {
                    MessageBox.Show("Removed: " + obj.cash_name);
                    _ShopItems.Remove(obj);
                    goto B3;
                }
            }

        B3:
            //Remove From WOrkingList Dictionary
            WorkingItemsList.Remove(listBox3.GetItemText(listBox3.SelectedItem));


            listBox3.Items.RemoveAt(listBox3.SelectedIndex);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Remove from Objects list
            foreach (var obj in _ShopItems)
            {
                if (listBox4.GetItemText(listBox4.SelectedItem).Contains(obj.cash_name))
                {
                    MessageBox.Show("Removed: " + obj.cash_name);
                    _ShopItems.Remove(obj);
                    goto B4;
                }
            }

        B4:
            //Remove From WOrkingList Dictionary
            WorkingItemsList.Remove(listBox4.GetItemText(listBox4.SelectedItem));


            listBox4.Items.RemoveAt(listBox4.SelectedIndex);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Remove from Objects list
            foreach (var obj in _ShopItems)
            {
                if (listBox5.GetItemText(listBox5.SelectedItem).Contains(obj.cash_name))
                {
                    MessageBox.Show("Removed: " + obj.cash_name);
                    _ShopItems.Remove(obj);
                    goto B5;
                }
            }

        B5:
            //Remove From WOrkingList Dictionary
            WorkingItemsList.Remove(listBox5.GetItemText(listBox5.SelectedItem));


            listBox5.Items.RemoveAt(listBox5.SelectedIndex);
        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Remove from Objects list
            foreach (var obj in _ShopItems)
            {
                if (listBox6.GetItemText(listBox6.SelectedItem).Contains(obj.cash_name))
                {
                    MessageBox.Show("Removed: " + obj.cash_name);
                    _ShopItems.Remove(obj);
                    goto B6;
                }
            }

        B6:
            //Remove From WOrkingList Dictionary
            WorkingItemsList.Remove(listBox6.GetItemText(listBox6.SelectedItem));


            listBox6.Items.RemoveAt(listBox6.SelectedIndex);
        }

        private void tabPage9_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

            // Remove from Objects list
            foreach (var obj in _ShopItems)
            {
                if (listBox7.GetItemText(listBox7.SelectedItem).Contains(obj.cash_name))
                {
                    MessageBox.Show("Removed: " + obj.cash_name);
                    _ShopItems.Remove(obj);
                    goto B7;
                }
            }

        B7:
            //Remove From WOrkingList Dictionary
            WorkingItemsList.Remove(listBox7.GetItemText(listBox7.SelectedItem));


            listBox7.Items.RemoveAt(listBox7.SelectedIndex);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button8_Click(object sender, EventArgs e)
        {
            cashShopItemTemplate xItem = new cashShopItemTemplate();
            //split up line and add to item object

            
           //sequential
            xItem.Id = ID_Count;
            ID_Count++;

            //randomGen
            var num = new Random();          
            xItem.uniq_id = num.Next(77770000);
                        
            xItem.cash_name = textBox1.Text;


            // check for main tab and set 
            var maintab = tabControl1.SelectedTab.Text;
            var subtab = tabControl2.SelectedTab.Text;
           //hard coding all tabs becuase fuck nesting an if 20 sumthing times
            xItem.main_tab = byte.Parse("1");
            //hard coding all tabs becuase fuck nesting an if 20 sumthing times
            xItem.sub_tab = byte.Parse("1");
                            
            xItem.level_min = byte.Parse(comboBox1.GetItemText(comboBox1.SelectedItem));
            xItem.level_max = byte.Parse(comboBox2.GetItemText(comboBox2.SelectedItem));
             
            xItem.item_template_id = int.Parse(textBox3.Text);


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
            xItem.price = int.Parse(textBox4.Text);
            xItem.remain = int.Parse(textBox5.Text);

            xItem.bonus_type = int.Parse("0");
            xItem.bouns_count = int.Parse("0");
            xItem.cmd_ui = byte.Parse("0");
            xItem.item_count = int.Parse("0");
            xItem.select_type = byte.Parse("0");
            xItem.default_flag = byte.Parse("0");
            xItem.event_type = byte.Parse("0");
            xItem.event_date = "0001-01-01 00:00:00";
            xItem.dis_price = int.Parse(textBox6.Text);


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
            if (WorkingItemsList.ContainsKey(xItem.cash_name) == false)
            {
                WorkingItemsList.Add(xItem.cash_name, xItem);
            }
            else
            {
                MessageBox.Show("Error: " + xItem.cash_name + " already in Dictionary");
            }
            //WorkingItemsList.Add(xItem.cash_name, xItem);

            if (listBox1.Items.Contains(xItem.cash_name) == false)
            {
                listBox1.Items.Add(xItem.cash_name);
            }
            else
            {
                MessageBox.Show("Error: " + xItem.cash_name + " already in ListBox");

            }
            //listBox3.Items.Add(xItem.cash_name);

            ////add item to list, dict and listbox
            //_ShopItems.Add(xItem);
            //WorkingItemsList.Add(xItem.cash_name, xItem);
            //listBox1.Items.Add(xItem.cash_name);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            cashShopItemTemplate xItem = new cashShopItemTemplate();
            //split up line and add to item object


            //sequential
            xItem.Id = ID_Count;
            ID_Count++;

            //randomGen
            var num = new Random();
            xItem.uniq_id = num.Next(77770000);

            xItem.cash_name = textBox11.Text;


            // check for main tab and set 
            var maintab = tabControl1.SelectedTab.Text;
            var subtab = tabControl2.SelectedTab.Text;
            //hard coding all tabs becuase fuck nesting an if 20 sumthing times
            xItem.main_tab = byte.Parse("1");
            //hard coding all tabs becuase fuck nesting an if 20 sumthing times
            xItem.sub_tab = byte.Parse("2");

            xItem.level_min = byte.Parse(comboBox4.GetItemText(comboBox4.SelectedItem));
            xItem.level_max = byte.Parse(comboBox3.GetItemText(comboBox3.SelectedItem));

            xItem.item_template_id = int.Parse(textBox10.Text);


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
            xItem.price = int.Parse(textBox9.Text);
            xItem.remain = int.Parse(textBox8.Text);

            xItem.bonus_type = int.Parse("0");
            xItem.bouns_count = int.Parse("0");
            xItem.cmd_ui = byte.Parse("0");
            xItem.item_count = int.Parse("0");
            xItem.select_type = byte.Parse("0");
            xItem.default_flag = byte.Parse("0");
            xItem.event_type = byte.Parse("0");
            xItem.event_date = "0001-01-01 00:00:00";
            xItem.dis_price = int.Parse(textBox7.Text);


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
            if (WorkingItemsList.ContainsKey(xItem.cash_name) == false)
            {
                WorkingItemsList.Add(xItem.cash_name, xItem);
            }
            else
            {
                MessageBox.Show("Error: " + xItem.cash_name + " already in Dictionary");
            }
            //WorkingItemsList.Add(xItem.cash_name, xItem);

            if (listBox2.Items.Contains(xItem.cash_name) == false)
            {
                listBox2.Items.Add(xItem.cash_name);
            }
            else
            {
                MessageBox.Show("Error: " + xItem.cash_name + " already in ListBox");

            }
            //listBox3.Items.Add(xItem.cash_name);
            ////add item to list, dict and listbox
            //_ShopItems.Add(xItem);
            //WorkingItemsList.Add(xItem.cash_name, xItem);
            //listBox2.Items.Add(xItem.cash_name);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            cashShopItemTemplate xItem = new cashShopItemTemplate();
            //split up line and add to item object


            //sequential
            xItem.Id = ID_Count;
            ID_Count++;

            //randomGen
            var num = new Random();
            xItem.uniq_id = num.Next(77770000);

            xItem.cash_name = textBox16.Text;


            // check for main tab and set 
            var maintab = tabControl1.SelectedTab.Text;
            var subtab = tabControl2.SelectedTab.Text;
            //hard coding all tabs becuase fuck nesting an if 20 sumthing times
            xItem.main_tab = byte.Parse("1");
            //hard coding all tabs becuase fuck nesting an if 20 sumthing times
            xItem.sub_tab = byte.Parse("3");

            xItem.level_min = byte.Parse(comboBox6.GetItemText(comboBox6.SelectedItem));
            xItem.level_max = byte.Parse(comboBox5.GetItemText(comboBox5.SelectedItem));

            xItem.item_template_id = int.Parse(textBox15.Text);


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
            xItem.price = int.Parse(textBox14.Text);
            xItem.remain = int.Parse(textBox13.Text);

            xItem.bonus_type = int.Parse("0");
            xItem.bouns_count = int.Parse("0");
            xItem.cmd_ui = byte.Parse("0");
            xItem.item_count = int.Parse("0");
            xItem.select_type = byte.Parse("0");
            xItem.default_flag = byte.Parse("0");
            xItem.event_type = byte.Parse("0");
            xItem.event_date = "0001-01-01 00:00:00";
            xItem.dis_price = int.Parse(textBox12.Text);


            //add item to list, dict and listbox needs checks for dups
            if (_ShopItems.Contains(xItem) == false)
            {
                _ShopItems.Add(xItem);
            } else 
            {
                MessageBox.Show("Error: "+ xItem.cash_name +" already in List"); 
            }
            //_ShopItems.Add(xItem);
            if (WorkingItemsList.ContainsKey(xItem.cash_name) == false)
            {
                WorkingItemsList.Add(xItem.cash_name, xItem);
            } else
            {
                MessageBox.Show("Error: " + xItem.cash_name + " already in Dictionary");
            }
            //WorkingItemsList.Add(xItem.cash_name, xItem);

            if (listBox3.Items.Contains(xItem.cash_name) == false)
            {
                listBox3.Items.Add(xItem.cash_name);
            }
            else
            {
                MessageBox.Show("Error: " + xItem.cash_name + " already in ListBox");

            }
            //listBox3.Items.Add(xItem.cash_name);
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            cashShopItemTemplate xItem = new cashShopItemTemplate();
            //split up line and add to item object


            //sequential
            xItem.Id = ID_Count;
            ID_Count++;

            //randomGen
            var num = new Random();
            xItem.uniq_id = num.Next(77770000);

            xItem.cash_name = textBox21.Text;


            // check for main tab and set 
            var maintab = tabControl1.SelectedTab.Text;
            var subtab = tabControl2.SelectedTab.Text;
            //hard coding all tabs becuase fuck nesting an if 20 sumthing times
            xItem.main_tab = byte.Parse("1");
            //hard coding all tabs becuase fuck nesting an if 20 sumthing times
            xItem.sub_tab = byte.Parse("4");

            xItem.level_min = byte.Parse(comboBox8.GetItemText(comboBox8.SelectedItem));
            xItem.level_max = byte.Parse(comboBox7.GetItemText(comboBox7.SelectedItem));

            xItem.item_template_id = int.Parse(textBox20.Text);


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
            xItem.price = int.Parse(textBox19.Text);
            xItem.remain = int.Parse(textBox18.Text);

            xItem.bonus_type = int.Parse("0");
            xItem.bouns_count = int.Parse("0");
            xItem.cmd_ui = byte.Parse("0");
            xItem.item_count = int.Parse("0");
            xItem.select_type = byte.Parse("0");
            xItem.default_flag = byte.Parse("0");
            xItem.event_type = byte.Parse("0");
            xItem.event_date = "0001-01-01 00:00:00";
            xItem.dis_price = int.Parse(textBox17.Text);


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
            if (WorkingItemsList.ContainsKey(xItem.cash_name) == false)
            {
                WorkingItemsList.Add(xItem.cash_name, xItem);
            }
            else
            {
                MessageBox.Show("Error: " + xItem.cash_name + " already in Dictionary");
            }
            //WorkingItemsList.Add(xItem.cash_name, xItem);

            if (listBox4.Items.Contains(xItem.cash_name) == false)
            {
                listBox4.Items.Add(xItem.cash_name);
            }
            else
            {
                MessageBox.Show("Error: " + xItem.cash_name + " already in ListBox");

            }
            //listBox3.Items.Add(xItem.cash_name);
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            cashShopItemTemplate xItem = new cashShopItemTemplate();
            //split up line and add to item object


            //sequential
            xItem.Id = ID_Count;
            ID_Count++;

            //randomGen
            var num = new Random();
            xItem.uniq_id = num.Next(77770000);

            xItem.cash_name = textBox26.Text;


            // check for main tab and set 
            var maintab = tabControl1.SelectedTab.Text;
            var subtab = tabControl2.SelectedTab.Text;
            //hard coding all tabs becuase fuck nesting an if 20 sumthing times
            xItem.main_tab = byte.Parse("1");
            //hard coding all tabs becuase fuck nesting an if 20 sumthing times
            xItem.sub_tab = byte.Parse("5");

            xItem.level_min = byte.Parse(comboBox10.GetItemText(comboBox10.SelectedItem));
            xItem.level_max = byte.Parse(comboBox9.GetItemText(comboBox9.SelectedItem));

            xItem.item_template_id = int.Parse(textBox25.Text);


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
            xItem.price = int.Parse(textBox24.Text);
            xItem.remain = int.Parse(textBox23.Text);

            xItem.bonus_type = int.Parse("0");
            xItem.bouns_count = int.Parse("0");
            xItem.cmd_ui = byte.Parse("0");
            xItem.item_count = int.Parse("0");
            xItem.select_type = byte.Parse("0");
            xItem.default_flag = byte.Parse("0");
            xItem.event_type = byte.Parse("0");
            xItem.event_date = "0001-01-01 00:00:00";
            xItem.dis_price = int.Parse(textBox22.Text);


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
            if (WorkingItemsList.ContainsKey(xItem.cash_name) == false)
            {
                WorkingItemsList.Add(xItem.cash_name, xItem);
            }
            else
            {
                MessageBox.Show("Error: " + xItem.cash_name + " already in Dictionary");
            }
            //WorkingItemsList.Add(xItem.cash_name, xItem);

            if (listBox5.Items.Contains(xItem.cash_name) == false)
            {
                listBox5.Items.Add(xItem.cash_name);
            }
            else
            {
                MessageBox.Show("Error: " + xItem.cash_name + " already in ListBox");

            }
            //listBox3.Items.Add(xItem.cash_name);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            cashShopItemTemplate xItem = new cashShopItemTemplate();
            //split up line and add to item object


            //sequential
            xItem.Id = ID_Count;
            ID_Count++;

            //randomGen
            var num = new Random();
            xItem.uniq_id = num.Next(77770000);

            xItem.cash_name = textBox31.Text;


            // check for main tab and set 
            var maintab = tabControl1.SelectedTab.Text;
            var subtab = tabControl2.SelectedTab.Text;
            //hard coding all tabs becuase fuck nesting an if 20 sumthing times
            xItem.main_tab = byte.Parse("1");
            //hard coding all tabs becuase fuck nesting an if 20 sumthing times
            xItem.sub_tab = byte.Parse("6");

            xItem.level_min = byte.Parse(comboBox12.GetItemText(comboBox12.SelectedItem));
            xItem.level_max = byte.Parse(comboBox11.GetItemText(comboBox11.SelectedItem));

            xItem.item_template_id = int.Parse(textBox30.Text);


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
            xItem.price = int.Parse(textBox29.Text);
            xItem.remain = int.Parse(textBox28.Text);

            xItem.bonus_type = int.Parse("0");
            xItem.bouns_count = int.Parse("0");
            xItem.cmd_ui = byte.Parse("0");
            xItem.item_count = int.Parse("0");
            xItem.select_type = byte.Parse("0");
            xItem.default_flag = byte.Parse("0");
            xItem.event_type = byte.Parse("0");
            xItem.event_date = "0001-01-01 00:00:00";
            xItem.dis_price = int.Parse(textBox27.Text);


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
            if (WorkingItemsList.ContainsKey(xItem.cash_name) == false)
            {
                WorkingItemsList.Add(xItem.cash_name, xItem);
            }
            else
            {
                MessageBox.Show("Error: " + xItem.cash_name + " already in Dictionary");
            }
            //WorkingItemsList.Add(xItem.cash_name, xItem);

            if (listBox6.Items.Contains(xItem.cash_name) == false)
            {
                listBox6.Items.Add(xItem.cash_name);
            }
            else
            {
                MessageBox.Show("Error: " + xItem.cash_name + " already in ListBox");

            }
            //listBox3.Items.Add(xItem.cash_name);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            cashShopItemTemplate xItem = new cashShopItemTemplate();
            //split up line and add to item object


            //sequential
            xItem.Id = ID_Count;
            ID_Count++;

            //randomGen
            var num = new Random();
            xItem.uniq_id = num.Next(77770000);

            xItem.cash_name = textBox36.Text;


            // check for main tab and set 
            var maintab = tabControl1.SelectedTab.Text;
            var subtab = tabControl2.SelectedTab.Text;
            //hard coding all tabs becuase fuck nesting an if 20 sumthing times
            xItem.main_tab = byte.Parse("1");
            //hard coding all tabs becuase fuck nesting an if 20 sumthing times
            xItem.sub_tab = byte.Parse("7");

            xItem.level_min = byte.Parse(comboBox14.GetItemText(comboBox14.SelectedItem));
            xItem.level_max = byte.Parse(comboBox13.GetItemText(comboBox13.SelectedItem));

            xItem.item_template_id = int.Parse(textBox35.Text);


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
            xItem.price = int.Parse(textBox34.Text);
            xItem.remain = int.Parse(textBox33.Text);

            xItem.bonus_type = int.Parse("0");
            xItem.bouns_count = int.Parse("0");
            xItem.cmd_ui = byte.Parse("0");
            xItem.item_count = int.Parse("0");
            xItem.select_type = byte.Parse("0");
            xItem.default_flag = byte.Parse("0");
            xItem.event_type = byte.Parse("0");
            xItem.event_date = "0001-01-01 00:00:00";
            xItem.dis_price = int.Parse(textBox32.Text);


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
            if (WorkingItemsList.ContainsKey(xItem.cash_name) == false)
            {
                WorkingItemsList.Add(xItem.cash_name, xItem);
            }
            else
            {
                MessageBox.Show("Error: " + xItem.cash_name + " already in Dictionary");
            }
            //WorkingItemsList.Add(xItem.cash_name, xItem);

            if (listBox7.Items.Contains(xItem.cash_name) == false)
            {
                listBox7.Items.Add(xItem.cash_name);
            }
            else
            {
                MessageBox.Show("Error: " + xItem.cash_name + " already in ListBox");

            }
            //listBox3.Items.Add(xItem.cash_name);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

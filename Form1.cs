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


                     
                        //Add to dictionary for later work
                        if (WorkingItemsList.ContainsKey(items.cash_name) == false)
                        {
                            WorkingItemsList.Add(items.cash_name, items);
                            //add to list
                            listBox9.Items.Add(BuiltItem);
                        }


                        
                       
                    }
                    else if (items.sub_tab.ToString() == "3") //subtab 3 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;

                       

                        //Add to dictionary for later work
                        if (WorkingItemsList.ContainsKey(items.cash_name) == false)
                        {
                            WorkingItemsList.Add(items.cash_name, items);
                            //add to list
                            listBox10.Items.Add(BuiltItem);
                        }
                    }
                    else if (items.sub_tab.ToString() == "4") //subtab 4 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;

                      

                        //Add to dictionary for later work
                        if (WorkingItemsList.ContainsKey(items.cash_name) == false)
                        {
                            WorkingItemsList.Add(items.cash_name, items);
                            //add to list
                            listBox11.Items.Add(BuiltItem);
                        }
                    }
                    else if (items.sub_tab.ToString() == "5") //subtab 5 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;


                        //Add to dictionary for later work
                        if (WorkingItemsList.ContainsKey(items.cash_name) == false)
                        {
                            WorkingItemsList.Add(items.cash_name, items);

                            //add to list
                            listBox12.Items.Add(BuiltItem);
                        }
                    }
                    else if (items.sub_tab.ToString() == "6") //subtab 6 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;

                      

                        //Add to dictionary for later work
                        if (WorkingItemsList.ContainsKey(items.cash_name) == false)
                        {
                            WorkingItemsList.Add(items.cash_name, items);
                            //add to list
                            listBox13.Items.Add(BuiltItem);
                        }
                    }
                    else if (items.sub_tab.ToString() == "7") //subtab 7 of 7
                    {
                        //build string
                        string BuiltItem = items.cash_name + " [Item ID: " + items.item_template_id + " ] " + Environment.NewLine;

                      

                        //Add to dictionary for later work
                       if (WorkingItemsList.ContainsKey(items.cash_name) == false)
                        {
                            WorkingItemsList.Add(items.cash_name, items);
                            //add to list
                            listBox14.Items.Add(BuiltItem);
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
            //\\____----____-____-_____-__-____-----___-___----___----___-----____----______------_____------_________----------____________-----------____________----------_______-----------_____
            //\\____----____-____-_____-__-____-----___-___----___----___-----____----______------_____------_________----------____________-----------____________----------_______-----------_____
            //\\____----____-____-_____-__-____-----___-___----___----___-----____----______------_____------_________----------____________-----------____________----------_______-----------_____
            //\\____----____-____-_____-__-____-----___-___----___----___-----____----______------_____------_________----------____________-----------____________----------_______-----------_____
            //\\____----____-____-_____-__-____-----___-___----___----___-----____----______------_____------_________----------____________-----------____________----------_______-----------_____
            //\\____----____-____-_____-__-____-----___-___----___----___-----____----______------_____------_________----------____________-----------____________----------_______-----------_____
            //\\____----____-____-_____-__-____-----___-___----___----___-----____----______------_____------_________----------____________-----------____________----------_______-----------_____
            //\\____----____-____-_____-__-____-----___-___----___----___-----____----______------_____------_________----------____________-----------____________----------_______-----------_____


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
            // AddItem(string itemName, string itemID, string price, string stock, string discount, string minLVL, string maxLVL, string mainTab, string subTab)
            AddItem(textBox1.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, comboBox1.GetItemText(comboBox1.SelectedItem), comboBox2.GetItemText(comboBox2.SelectedItem), "1", "1");


        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            // AddItem(string itemName, string itemID, string price, string stock, string discount, string minLVL, string maxLVL, string mainTab, string subTab)
            AddItem(textBox11.Text, textBox10.Text, textBox9.Text, textBox8.Text, textBox7.Text, comboBox4.GetItemText(comboBox4.SelectedItem), comboBox3.GetItemText(comboBox3.SelectedItem), "1", "2");

        }

        private void button10_Click(object sender, EventArgs e)
        {
            // AddItem(string itemName, string itemID, string price, string stock, string discount, string minLVL, string maxLVL, string mainTab, string subTab)
            AddItem(textBox16.Text, textBox15.Text, textBox14.Text, textBox13.Text, textBox12.Text, comboBox6.GetItemText(comboBox6.SelectedItem), comboBox5.GetItemText(comboBox5.SelectedItem), "1", "3");

        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

             AddItem(textBox21.Text, textBox20.Text, textBox19.Text, textBox18.Text, textBox17.Text, comboBox8.GetItemText(comboBox8.SelectedItem), comboBox7.GetItemText(comboBox7.SelectedItem), "1", "4");
         
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

            AddItem(textBox26.Text, textBox25.Text, textBox24.Text, textBox23.Text, textBox22.Text, comboBox10.GetItemText(comboBox10.SelectedItem), comboBox9.GetItemText(comboBox9.SelectedItem), "1", "5");

        }

        private void button13_Click(object sender, EventArgs e)
        {

             AddItem(textBox31.Text, textBox30.Text, textBox29.Text, textBox28.Text, textBox27.Text, comboBox12.GetItemText(comboBox12.SelectedItem), comboBox11.GetItemText(comboBox11.SelectedItem), "1", "6");

        }

        private void button14_Click(object sender, EventArgs e)
        {
             AddItem(textBox36.Text, textBox35.Text, textBox34.Text, textBox33.Text, textBox32.Text, comboBox14.GetItemText(comboBox14.SelectedItem), comboBox13.GetItemText(comboBox13.SelectedItem), "1", "7");

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

            // Remove from Objects list
            foreach (var obj in _ShopItems)
            {
                if (listBox8.GetItemText(listBox8.SelectedItem).Contains(obj.cash_name))
                {
                    MessageBox.Show("Removed: " + obj.cash_name);
                    _ShopItems.Remove(obj);
                    goto B8;
                }
            }

        B8:
            //Remove From WOrkingList Dictionary
            WorkingItemsList.Remove(listBox8.GetItemText(listBox8.SelectedItem));


            listBox8.Items.RemoveAt(listBox8.SelectedIndex);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            //MAINTAB/2

            // Remove from Objects list
            foreach (var obj in _ShopItems)
            {
                if (listBox9.GetItemText(listBox9.SelectedItem).Contains(obj.cash_name))
                {
                    MessageBox.Show("Removed: " + obj.cash_name);
                    _ShopItems.Remove(obj);
                    goto B8;
                }
            }

        B8:
            //Remove From WOrkingList Dictionary
            WorkingItemsList.Remove(listBox9.GetItemText(listBox9.SelectedItem));


            listBox9.Items.RemoveAt(listBox9.SelectedIndex);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            //MAINTAB/2

            // Remove from Objects list
            foreach (var obj in _ShopItems)
            {
                if (listBox10.GetItemText(listBox10.SelectedItem).Contains(obj.cash_name))
                {
                    MessageBox.Show("Removed: " + obj.cash_name);
                    _ShopItems.Remove(obj);
                    goto B8;
                }
            }

        B8:
            //Remove From WOrkingList Dictionary
            WorkingItemsList.Remove(listBox10.GetItemText(listBox10.SelectedItem));


            listBox10.Items.RemoveAt(listBox10.SelectedIndex);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            //MAINTAB/2

            // Remove from Objects list
            foreach (var obj in _ShopItems)
            {
                if (listBox11.GetItemText(listBox11.SelectedItem).Contains(obj.cash_name))
                {
                    MessageBox.Show("Removed: " + obj.cash_name);
                    _ShopItems.Remove(obj);
                    goto B8;
                }
            }

        B8:
            //Remove From WOrkingList Dictionary
            WorkingItemsList.Remove(listBox11.GetItemText(listBox11.SelectedItem));


            listBox11.Items.RemoveAt(listBox11.SelectedIndex);
        }

        private void button24_Click(object sender, EventArgs e)
        {
             //MAINTAB/2

            // Remove from Objects list
            foreach (var obj in _ShopItems)
            {
                if (listBox12.GetItemText(listBox12.SelectedItem).Contains(obj.cash_name))
                {
                    MessageBox.Show("Removed: " + obj.cash_name);
                    _ShopItems.Remove(obj);
                    goto B8;
                }
            }

        B8:
            //Remove From WOrkingList Dictionary
            WorkingItemsList.Remove(listBox12.GetItemText(listBox12.SelectedItem));


            listBox12.Items.RemoveAt(listBox12.SelectedIndex);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            //MAINTAB/2

            // Remove from Objects list
            foreach (var obj in _ShopItems)
            {
                if (listBox13.GetItemText(listBox13.SelectedItem).Contains(obj.cash_name))
                {
                    MessageBox.Show("Removed: " + obj.cash_name);
                    _ShopItems.Remove(obj);
                    goto B8;
                }
            }

        B8:
            //Remove From WOrkingList Dictionary
            WorkingItemsList.Remove(listBox13.GetItemText(listBox13.SelectedItem));


            listBox13.Items.RemoveAt(listBox13.SelectedIndex);
        }

        private void tabControl3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {
            //MAINTAB/2

            // Remove from Objects list
            foreach (var obj in _ShopItems)
            {
                if (listBox14.GetItemText(listBox14.SelectedItem).Contains(obj.cash_name))
                {
                    MessageBox.Show("Removed: " + obj.cash_name);
                    _ShopItems.Remove(obj);
                    goto B8;
                }
            }

        B8:
            //Remove From WOrkingList Dictionary
            WorkingItemsList.Remove(listBox14.GetItemText(listBox14.SelectedItem));


            listBox14.Items.RemoveAt(listBox14.SelectedIndex);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // AddItem(string itemName, string itemID, string price, string stock, string discount, string minLVL, string maxLVL, string mainTab, string subTab)
            AddItem(textBox41.Text, textBox40.Text, textBox39.Text, textBox38.Text,
                    textBox37.Text, comboBox15.GetItemText(comboBox15.SelectedItem),
                    comboBox16.GetItemText(comboBox16.SelectedItem), "2", "1");
          
        }

        private void button17_Click(object sender, EventArgs e)
        {
            AddItem(textBox46.Text, textBox45.Text, textBox43.Text, textBox44.Text, textBox42.Text, comboBox17.GetItemText(comboBox17.SelectedItem), comboBox18.GetItemText(comboBox18.SelectedItem), "2", "2");
            
         
        }

        private void textBox45_TextChanged(object sender, EventArgs e)
        {

        }

        public void AddItem(string itemName, string itemID, string price, string stock, string discount, string minLVL, string maxLVL, string mainTab, string subTab ) 
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
    }
}

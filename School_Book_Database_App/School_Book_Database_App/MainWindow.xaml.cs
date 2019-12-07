using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace School_Book_Database_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region lists variables Initialised and Declared => instances

        //list of tables in DB 
        List<Student> studentTest = new List<Student>();
        List<SBOrder> sbOrdersTest = new List<SBOrder>();
        List<SBInventory> sbInventoryTest = new List<SBInventory>();

        //List of classes
        List<Students> student = new List<Students>();
        List<SchoolBookOrders> sbOrders = new List<SchoolBookOrders>();
        List<SchoolBooksInventory> sbInventory = new List<SchoolBooksInventory>();

        //Instanciating table classes in DB 
        Student st = new Student();
        SBOrder sbO = new SBOrder();
        SBInventory sbIn = new SBInventory();
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }


        void Initialise() 
        {

            #region View Tables from DB in each tab separately

            using (var db = new SchoolBooksDBEntities())
            {
                studentTest = db.Students.ToList();
                sbOrdersTest = db.SBOrders.ToList();
                sbInventoryTest = db.SBInventories.ToList();
            }

            listViewStudents.ItemsSource = studentTest;
            ListviewOrder.ItemsSource = sbOrdersTest;
            ListViewInventory.ItemsSource = sbInventoryTest;
            #endregion

            #region using classes the that I have made to the database

            using (var db = new SchoolBooksDBEntities()) 
            {
                var studentListView = from st in db.Students
                                      select new Students()
                                      {
                                          studentId = st.StudentID,
                                          orderBooksId = (int)st.OrderBooksID,
                                          firstName = st.FirstName,
                                          lastName = st.LastName,
                                          schoolYear = (int)st.SchoolYear,
                                          subjects = st.Subjects,
                                          examBoardLv = st.ExamBoardAndLevel,
                                          booksCollected = (bool)st.BooksRecieved,
                                          bookStatus = st.BookStatus
                                      };

                student = studentListView.ToList();
               // listViewStudents.ItemsSource = student;

            }
           
            using (var db = new SchoolBooksDBEntities()) 
            {
                var bookOrderList = from sbO in db.SBOrders
                                    select new SchoolBookOrders() 
                                    {
                                        orderBookId = sbO.OrderBooksId,
                                        bookInventoryId = (int)sbO.BookInventoryID,
                                        subject = sbO.Subject,
                                        bookName = sbO.BookName,
                                        examBoard = sbO.ExamBoardAndLevel,
                                        bookType = sbO.BookType,
                                        quantyOrder = (int)sbO.QuantityOrdered,
                                        totalCost = Math.Round((double)sbO.TotalCostOfBooks, 2),
                                        dateOrdered = (DateTime)sbO.DateOrdered,
                                        dateOrderResieved = (DateTime)sbO.DateOrderRecieved,
                                        notes = sbO.Notes

                                    };
                sbOrders = bookOrderList.ToList();
              //  ListviewOrder.ItemsSource = sbOrders;

            }

            using (var db = new SchoolBooksDBEntities()) 
            {
                var schoolBookInventoryList = from sbIn in db.SBInventories
                                              select new SchoolBooksInventory() 
                                              {
                                                  bookInventoryId = sbIn.BookInventoryId,
                                                  subject = sbIn.Subject,
                                                  bookInventoryName = sbIn.BookName,
                                                  examBoardLevel = sbIn.ExamBoardAndLevel,
                                                  bookType = sbIn.BookType,
                                                  bookStatus = sbIn.BookSatus,
                                                  Notes = sbIn.Notes
                                              };


                sbInventory = schoolBookInventoryList.ToList();
               // ListViewInventory.ItemsSource = sbInventory;
              
            }

            #endregion

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (AddButton.Content.ToString() == "Add")
            {
                
                AddButton.Content = "Confirm";
                TextBox8.IsEnabled = true;
                ComboBox8.IsEnabled = false;
                TextBox8.Visibility = Visibility.Visible;
                ComboBox8.Visibility = Visibility.Hidden;

                // Button is  enabled
                AddButton.IsEnabled = true;
                EditButton.IsEnabled = true;
                DeleteButton.IsEnabled = true;

                // calling the selected item on the list table(s). 
                st = (Student)listViewStudents.SelectedItem;
                sbO = (SBOrder)ListviewOrder.SelectedItem;
                sbIn = (SBInventory)ListViewInventory.SelectedItem;

                if (st != null)
                {
                    #region clearing the textboxes
                    // set empty textboxes 
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";
                    TextBox5.Text = "";
                    TextBox6.Text = "";
                    TextBox7.Text = "";
                    TextBox8.Text = "";
                    TextBox9.Text = "";
                    #endregion

                    #region textboxes are not ReadOnly

                    TextBox2.IsReadOnly = false;
                    TextBox3.IsReadOnly = false;
                    TextBox4.IsReadOnly = false;
                    TextBox5.IsReadOnly = false;
                    TextBox6.IsReadOnly = false;
                    TextBox7.IsReadOnly = false;
                    TextBox8.IsReadOnly = false;
                    ComboBox8.IsReadOnly = false;
                    TextBox9.IsReadOnly = false;

                    #endregion

                    #region change background color

                    TextBox2.Background = Brushes.White;
                    TextBox3.Background = Brushes.White;
                    TextBox4.Background = Brushes.White;
                    TextBox5.Background = Brushes.White;
                    TextBox6.Background = Brushes.White;
                    TextBox7.Background = Brushes.White;
                    TextBox8.Background = Brushes.White;
                    ComboBox8.Background = Brushes.White;
                    TextBox9.Background = Brushes.White;
                    TextBox10.Background = Brushes.White;
                    TextBox11.Background = Brushes.White;
                    Label10.Background = Brushes.White;
                    Label11.Background = Brushes.White;
                    #endregion
                }
                else if (sbO != null)
                {
                    #region clearing the textboxes
                    // set boxes to clear
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";
                    TextBox5.Text = "";
                    TextBox6.Text = "";
                    TextBox7.Text = "";
                    TextBox8.Text = "";
                    TextBox9.Text = "";
                    TextBox10.Text = "";
                    TextBox11.Text = "";
                    #endregion

                    #region textboxes are not ReadOnly

                    TextBox2.IsReadOnly = false;
                    TextBox3.IsReadOnly = false;
                    TextBox4.IsReadOnly = false;
                    TextBox5.IsReadOnly = false;
                    TextBox6.IsReadOnly = false;
                    TextBox7.IsReadOnly = false;
                    TextBox8.IsReadOnly = false;
                    ComboBox8.IsReadOnly = false;
                    TextBox9.IsReadOnly = false;
                    TextBox10.IsReadOnly = false;
                    TextBox11.IsReadOnly = false;
                    #endregion

                    #region change background color

                    TextBox2.Background = Brushes.White;
                    TextBox3.Background = Brushes.White;
                    TextBox4.Background = Brushes.White;
                    TextBox5.Background = Brushes.White;
                    TextBox6.Background = Brushes.White;
                    TextBox7.Background = Brushes.White;
                    TextBox8.Background = Brushes.White;
                    ComboBox8.Background = Brushes.White;
                    TextBox9.Background = Brushes.White;
                    TextBox10.Background = Brushes.White;
                    TextBox11.Background = Brushes.White;

                    #endregion

                } else if (sbIn != null) 
                {
                    #region clearing the textboxes
                    // set boxes to clear
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";
                    TextBox5.Text = "";
                    TextBox6.Text = "";
                    TextBox7.Text = "";
                    TextBox8.Text = "";
                    
                    #endregion

                    #region textboxes are not ReadOnly

                    TextBox2.IsReadOnly = false;
                    TextBox3.IsReadOnly = false;
                    TextBox4.IsReadOnly = false;
                    TextBox5.IsReadOnly = false;
                    TextBox6.IsReadOnly = false;
                    TextBox7.IsReadOnly = false;
                    TextBox8.IsReadOnly = false;
                    ComboBox8.IsReadOnly = false;
                   

                    #endregion

                    #region change background color

                    TextBox2.Background = Brushes.White;
                    TextBox3.Background = Brushes.White;
                    TextBox4.Background = Brushes.White;
                    TextBox5.Background = Brushes.White;
                    TextBox6.Background = Brushes.White;
                    TextBox7.Background = Brushes.White;
                    TextBox8.Background = Brushes.White;
                    ComboBox8.Background = Brushes.White;
                    TextBox9.Background = Brushes.White;
                    TextBox10.Background = Brushes.White;
                    TextBox11.Background = Brushes.White;
                    Label9.Background = Brushes.White;
                    Label10.Background = Brushes.White;
                    Label11.Background = Brushes.White;
                    #endregion
                }

            }
            else
            {
                AddButton.Content = "Add";
                var brush = new BrushConverter();

                TextBox8.IsEnabled = true;
                ComboBox8.IsEnabled = false;
                TextBox8.Visibility = Visibility.Hidden;
                ComboBox8.Visibility = Visibility.Visible;

                // set the textboxes to ReadOnly
                #region textboxes are ReadOnly
                TextBox1.IsReadOnly = true;
                TextBox2.IsReadOnly = true;
                TextBox3.IsReadOnly = true;
                TextBox4.IsReadOnly = true;
                TextBox5.IsReadOnly = true;
                TextBox6.IsReadOnly = true;
                TextBox7.IsReadOnly = true;
                TextBox8.IsReadOnly = true;
                ComboBox8.IsReadOnly = true;
                TextBox9.IsReadOnly = true;
                TextBox10.IsReadOnly = true;
                TextBox11.IsReadOnly = true;
                #endregion

                // changing the background color back to the initial color
                #region change background color
                TextBox1.Background = (Brush)brush.ConvertFrom("BlanchedAlmond");
                TextBox2.Background = (Brush)brush.ConvertFrom("BlanchedAlmond"); 
                TextBox3.Background = (Brush)brush.ConvertFrom("BlanchedAlmond"); 
                TextBox4.Background = (Brush)brush.ConvertFrom("BlanchedAlmond");
                TextBox5.Background = (Brush)brush.ConvertFrom("BlanchedAlmond");
                TextBox6.Background = (Brush)brush.ConvertFrom("BlanchedAlmond");
                TextBox7.Background = (Brush)brush.ConvertFrom("BlanchedAlmond");
                TextBox8.Background = (Brush)brush.ConvertFrom("BlanchedAlmond");
                ComboBox8.Background = (Brush)brush.ConvertFrom("BlanchedAlmond");
                TextBox9.Background = (Brush)brush.ConvertFrom("BlanchedAlmond");
                TextBox10.Background = (Brush)brush.ConvertFrom("BlanchedAlmond");
                TextBox11.Background = (Brush)brush.ConvertFrom("BlanchedAlmond");
                Label9.Background = Brushes.Aquamarine;
                Label10.Background = Brushes.Aquamarine;
                Label11.Background = Brushes.Aquamarine;

                #endregion

                // add a record to students table
                #region adding a student record into Students table

                int.TryParse(TextBox2.Text, out int orderBooksId);
                int.TryParse(TextBox5.Text, out int schoolYear);
                bool.TryParse(TextBox8.Text, out bool collected);

                st = (Student)listViewStudents.SelectedItem;
                if (st != null) 
                {
                    var addToStudentTable = new Student()
                    {
                        OrderBooksID = orderBooksId,
                        FirstName = TextBox3.Text,
                        LastName = TextBox4.Text,
                        SchoolYear = schoolYear,
                        Subjects = TextBox6.Text,
                        ExamBoardAndLevel = TextBox7.Text,
                        BooksRecieved = collected,
                        BookStatus = TextBox9.Text

                    };

                    using (var db = new SchoolBooksDBEntities()) 
                    {
                        db.Students.Add(addToStudentTable);

                        db.SaveChanges();
                        listViewStudents.ItemsSource = null;
                        studentTest = db.Students.ToList();
                        listViewStudents.ItemsSource = studentTest;
                        AddButton.IsEnabled = false;
                        EditButton.IsEnabled = false;
                        DeleteButton.IsEnabled = false;
                    }
                    
                }

                #endregion

                // add a record to BookOrder table
                #region adding a order books record into bookOrders table

                int.TryParse(TextBox2.Text, out int inventoryId);
                int.TryParse(TextBox6.Text, out int quantityOrdered);
                Decimal.TryParse(TextBox7.Text, out Decimal totalCostOfBooks);
              
                TextBox9.Text = SelectDate.SelectedDate.ToString();
                DateTime.TryParse(TextBox9.Text, out DateTime selectedDateOrdered);
                
                TextBox10.Text = SelectDate.SelectedDate.ToString();
                DateTime.TryParse(TextBox10.Text, out DateTime selectedDateRecieved);
                sbO = (SBOrder)ListviewOrder.SelectedItem;
                if (sbO != null) 
                {
                    var addBookOrder = new SBOrder()
                    {
                        BookInventoryID = inventoryId,
                        Subject = TextBox3.Text,
                        BookName = TextBox4.Text,
                        ExamBoardAndLevel = TextBox5.Text,
                        QuantityOrdered = quantityOrdered,
                        TotalCostOfBooks = totalCostOfBooks,
                        BookType = TextBox8.Text,
                        DateOrdered = selectedDateOrdered,
                        DateOrderRecieved = selectedDateRecieved,
                        Notes = TextBox11.Text

                    };

                    using (var db = new SchoolBooksDBEntities()) 
                    {
                          db.SBOrders.Add(addBookOrder);

                        db.SaveChanges();
                        ListviewOrder.ItemsSource = null;
                        sbOrdersTest = db.SBOrders.ToList();
                        ListviewOrder.ItemsSource = sbOrdersTest;
                        AddButton.IsEnabled = false;
                        EditButton.IsEnabled = false;
                        DeleteButton.IsEnabled = false;
                    }
                }


                #endregion

                // add a record to SBinventory table
                #region adding a record to inventory table

                int.TryParse(TextBox6.Text, out int quantityInStock);
                sbIn = (SBInventory)ListViewInventory.SelectedItem;
                if (sbIn != null) 
                {
                    var addBookInventory = new SBInventory()
                    {
                        Subject = TextBox2.Text,
                        BookName = TextBox3.Text,
                        ExamBoardAndLevel = TextBox4.Text,
                        BookType = TextBox5.Text,
                        QuantityInStock = quantityInStock,
                        Notes = TextBox7.Text,
                        BookSatus = TextBox8.Text


                    };


                    using (var db = new SchoolBooksDBEntities()) 
                    {
                        db.SBInventories.Add(addBookInventory);

                        db.SaveChanges();
                        ListViewInventory.ItemsSource = null;
                        sbInventoryTest = db.SBInventories.ToList();
                        ListViewInventory.ItemsSource = sbInventoryTest;
                        AddButton.IsEnabled = false;
                        EditButton.IsEnabled = false;
                        DeleteButton.IsEnabled = false;

                    }
                }

                #endregion


            }

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (EditButton.Content.ToString() == "Edit")
            {
                EditButton.Content = "Update";
                EditButton.Background = Brushes.Orange;

                TextBox8.IsEnabled = false;
                ComboBox8.IsEnabled = true;
                TextBox8.Visibility = Visibility.Hidden;
                ComboBox8.Visibility = Visibility.Visible;


                st = (Student)listViewStudents.SelectedItem;
                sbO = (SBOrder)ListviewOrder.SelectedItem;
                sbIn = (SBInventory)ListViewInventory.SelectedItem;


                if (st != null)
                {
                    

                    #region textboxes are not ReadOnly

                    TextBox2.IsReadOnly = false;
                    TextBox3.IsReadOnly = false;
                    TextBox4.IsReadOnly = false;
                    TextBox5.IsReadOnly = false;
                    TextBox6.IsReadOnly = false;
                    TextBox7.IsReadOnly = false;
                    TextBox8.IsReadOnly = false;
                    ComboBox8.IsReadOnly = false;
                    TextBox9.IsReadOnly = false;

                    #endregion

                    #region change background color

                    TextBox2.Background = Brushes.White;
                    TextBox3.Background = Brushes.White;
                    TextBox4.Background = Brushes.White;
                    TextBox5.Background = Brushes.White;
                    TextBox6.Background = Brushes.White;
                    TextBox7.Background = Brushes.White;
                    TextBox8.Background = Brushes.White;
                    ComboBox8.Background = Brushes.White;
                    TextBox9.Background = Brushes.White;
                    TextBox10.Background = Brushes.White;
                    TextBox11.Background = Brushes.White;
                    Label10.Background = Brushes.White;
                    Label11.Background = Brushes.White;
                    #endregion

                }
                else if (sbO != null)
                {

                    #region textboxes are not ReadOnly

                    TextBox2.IsReadOnly = false;
                    TextBox3.IsReadOnly = false;
                    TextBox4.IsReadOnly = false;
                    TextBox5.IsReadOnly = false;
                    TextBox6.IsReadOnly = false;
                    TextBox7.IsReadOnly = false;
                    TextBox8.IsReadOnly = false;
                    ComboBox8.IsReadOnly = false;
                    TextBox9.IsReadOnly = false;
                    TextBox10.IsReadOnly = false;
                    TextBox11.IsReadOnly = false;
                    #endregion

                    #region change background color

                    TextBox2.Background = Brushes.White;
                    TextBox3.Background = Brushes.White;
                    TextBox4.Background = Brushes.White;
                    TextBox5.Background = Brushes.White;
                    TextBox6.Background = Brushes.White;
                    TextBox7.Background = Brushes.White;
                    TextBox8.Background = Brushes.White;
                    ComboBox8.Background = Brushes.White;
                    TextBox9.Background = Brushes.White;
                    TextBox10.Background = Brushes.White;
                    TextBox11.Background = Brushes.White;

                    #endregion

                }
                else if (sbIn != null)
                {


                    #region textboxes are not ReadOnly

                    TextBox2.IsReadOnly = false;
                    TextBox3.IsReadOnly = false;
                    TextBox4.IsReadOnly = false;
                    TextBox5.IsReadOnly = false;
                    TextBox6.IsReadOnly = false;
                    TextBox7.IsReadOnly = false;
                    ComboBox8.IsReadOnly = false;


                    #endregion

                    #region change background color

                    TextBox2.Background = Brushes.White;
                    TextBox3.Background = Brushes.White;
                    TextBox4.Background = Brushes.White;
                    TextBox5.Background = Brushes.White;
                    TextBox6.Background = Brushes.White;
                    TextBox7.Background = Brushes.White;
                    TextBox8.Background = Brushes.White;
                    ComboBox8.Background = Brushes.White;
                    TextBox9.Background = Brushes.White;
                    TextBox10.Background = Brushes.White;
                    TextBox11.Background = Brushes.White;
                    Label9.Background = Brushes.White;
                    Label10.Background = Brushes.White;
                    Label11.Background = Brushes.White;
                    #endregion
                }

            }
            else 
            {
                EditButton.Content = "Update";
                EditButton.Background = Brushes.LightGoldenrodYellow;
                var editBrush = new BrushConverter();

                // set the textboxes to ReadOnly
                #region textboxes are ReadOnly
                TextBox1.IsReadOnly = true;
                TextBox2.IsReadOnly = true;
                TextBox3.IsReadOnly = true;
                TextBox4.IsReadOnly = true;
                TextBox5.IsReadOnly = true;
                TextBox6.IsReadOnly = true;
                TextBox7.IsReadOnly = true;
                TextBox8.IsReadOnly = true;
                ComboBox8.IsReadOnly = true;
                TextBox9.IsReadOnly = true;
                TextBox10.IsReadOnly = true;
                TextBox11.IsReadOnly = true;
                #endregion

                // changing the background color back to the initial color
                #region change background color
                TextBox1.Background = (Brush)editBrush.ConvertFrom("BlanchedAlmond");
                TextBox2.Background = (Brush)editBrush.ConvertFrom("BlanchedAlmond");
                TextBox3.Background = (Brush)editBrush.ConvertFrom("BlanchedAlmond");
                TextBox4.Background = (Brush)editBrush.ConvertFrom("BlanchedAlmond");
                TextBox5.Background = (Brush)editBrush.ConvertFrom("BlanchedAlmond");
                TextBox6.Background = (Brush)editBrush.ConvertFrom("BlanchedAlmond");
                TextBox7.Background = (Brush)editBrush.ConvertFrom("BlanchedAlmond");
                TextBox8.Background = (Brush)editBrush.ConvertFrom("BlanchedAlmond");
                ComboBox8.Background = (Brush)editBrush.ConvertFrom("BlanchedAlmond");
                TextBox9.Background = (Brush)editBrush.ConvertFrom("BlanchedAlmond");
                TextBox10.Background = (Brush)editBrush.ConvertFrom("BlanchedAlmond");
                TextBox11.Background = (Brush)editBrush.ConvertFrom("BlanchedAlmond");
                Label9.Background = Brushes.Aquamarine;
                Label10.Background = Brushes.Aquamarine;
                Label11.Background = Brushes.Aquamarine;

                #endregion

                // add a record to students table
                #region adding a student record into Students table

                int.TryParse(TextBox2.Text, out int orderBooksId);
                int.TryParse(TextBox5.Text, out int schoolYear);
                bool.TryParse(TextBox8.Text, out bool collected);

                st = (Student)listViewStudents.SelectedItem;
                if (st != null)
                {
                    var addToStudentTable = new Student()
                    {
                        OrderBooksID = orderBooksId,
                        FirstName = TextBox3.Text,
                        LastName = TextBox4.Text,
                        SchoolYear = schoolYear,
                        Subjects = TextBox6.Text,
                        ExamBoardAndLevel = TextBox7.Text,
                        BooksRecieved = collected,
                        BookStatus = TextBox9.Text

                    };

                    using (var db = new SchoolBooksDBEntities())
                    {
                        db.Students.Add(addToStudentTable);

                        db.SaveChanges();
                        listViewStudents.ItemsSource = null;
                        studentTest = db.Students.ToList();
                        listViewStudents.ItemsSource = studentTest;
                        AddButton.IsEnabled = false;
                        EditButton.IsEnabled = false;
                        DeleteButton.IsEnabled = false;
                    }

                }

                #endregion

                // add a record to BookOrder table
                #region adding a order books record into bookOrders table

                int.TryParse(TextBox2.Text, out int inventoryId);
                int.TryParse(TextBox6.Text, out int quantityOrdered);
                Decimal.TryParse(TextBox7.Text, out Decimal totalCostOfBooks);

                TextBox9.Text = SelectDate.SelectedDate.ToString();
                DateTime.TryParse(TextBox9.Text, out DateTime selectedDateOrdered);

                TextBox10.Text = SelectDate.SelectedDate.ToString();
                DateTime.TryParse(TextBox10.Text, out DateTime selectedDateRecieved);
                sbO = (SBOrder)ListviewOrder.SelectedItem;
                if (sbO != null)
                {
                    var addBookOrder = new SBOrder()
                    {
                        BookInventoryID = inventoryId,
                        Subject = TextBox3.Text,
                        BookName = TextBox4.Text,
                        ExamBoardAndLevel = TextBox5.Text,
                        QuantityOrdered = quantityOrdered,
                        TotalCostOfBooks = totalCostOfBooks,
                        BookType = TextBox8.Text,
                        DateOrdered = selectedDateOrdered,
                        DateOrderRecieved = selectedDateRecieved,
                        Notes = TextBox11.Text

                    };

                    using (var db = new SchoolBooksDBEntities())
                    {
                        db.SBOrders.Add(addBookOrder);

                        db.SaveChanges();
                        ListviewOrder.ItemsSource = null;
                        sbOrdersTest = db.SBOrders.ToList();
                        ListviewOrder.ItemsSource = sbOrdersTest;
                        AddButton.IsEnabled = false;
                        EditButton.IsEnabled = false;
                        DeleteButton.IsEnabled = false;
                    }
                }


                #endregion

                // add a record to SBinventory table
                #region adding a record to inventory table

                int.TryParse(TextBox6.Text, out int quantityInStock);
                sbIn = (SBInventory)ListViewInventory.SelectedItem;
                if (sbIn != null)
                {
                    var addBookInventory = new SBInventory()
                    {
                        Subject = TextBox2.Text,
                        BookName = TextBox3.Text,
                        ExamBoardAndLevel = TextBox4.Text,
                        BookType = TextBox5.Text,
                        QuantityInStock = quantityInStock,
                        Notes = TextBox7.Text,
                        BookSatus = TextBox8.Text


                    };


                    using (var db = new SchoolBooksDBEntities())
                    {
                        db.SBInventories.Add(addBookInventory);

                        db.SaveChanges();
                        ListViewInventory.ItemsSource = null;
                        sbInventoryTest = db.SBInventories.ToList();
                        ListViewInventory.ItemsSource = sbInventoryTest;
                        AddButton.IsEnabled = false;
                        EditButton.IsEnabled = false;
                        DeleteButton.IsEnabled = false;

                    }
                }

                #endregion

            }
        }

        private void ListViewstudentsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            using (var db = new SchoolBooksDBEntities())
            {
                studentTest = db.Students.ToList();
            }

            st = (Student)listViewStudents.SelectedItem;
            if (st!=null) 
            {
                AddButton.IsEnabled = true;
                EditButton.IsEnabled = true;
                DeleteButton.IsEnabled = true;

                #region label Content Name Change
                Label1.Content = "Student ID";
                Label2.Content = "Order ID";
                Label3.Content = "First Name";
                Label4.Content = "Last Name";
                Label5.Content = "School\nYear";
                Label6.Content = "Subjects";
                Label7.Content = "ExamBoard\n(Lv)";
                Label8.Content = "Book(s)\nRecieved";
                Label9.Content = "Book\nStatus";
                #endregion

                #region Database to Textbox inserting database Columns ito each textbox
                TextBox1.Text = st.StudentID.ToString();
                TextBox2.Text = st.OrderBooksID.ToString();
                TextBox3.Text = st.FirstName;
                TextBox4.Text = st.LastName;
                TextBox5.Text = st.SchoolYear.ToString();
                TextBox6.Text = st.Subjects;
                TextBox7.Text = st.ExamBoardAndLevel;
                ComboBox8.ItemsSource = studentTest;
                ComboBox8.DisplayMemberPath = "BooksRecieved";
                ComboBox8.FontSize = 8;
                TextBox9.Text = st.BookStatus;
                #endregion

                #region textboxes are ReadOnly
                TextBox1.IsReadOnly = true;
                TextBox2.IsReadOnly = true;
                TextBox3.IsReadOnly = true;
                TextBox4.IsReadOnly = true;
                TextBox5.IsReadOnly = true;
                TextBox6.IsReadOnly = true;
                TextBox7.IsReadOnly = true;
                TextBox8.IsReadOnly = true;
                ComboBox8.IsReadOnly = true;
                TextBox9.IsReadOnly = true;
                TextBox10.IsReadOnly = true;
                TextBox11.IsReadOnly = true;
                #endregion

                #region Empty labels and textboxes not being used
                Label10.Content = "";
                Label11.Content = "";
                TextBox10.Text = "";
                TextBox11.Text = "";
                #endregion

            }
        }

        private void ListViewOrdersSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var db = new SchoolBooksDBEntities()) 
            {
                sbOrdersTest = db.SBOrders.ToList();
            }

                sbO = (SBOrder)ListviewOrder.SelectedItem;
            if (sbO != null) 
            {
                AddButton.IsEnabled = true;
                EditButton.IsEnabled = true;
                DeleteButton.IsEnabled = true;

                #region label Content Name Change
                Label1.Content = "Order ID";
                Label2.Content = "Inventory\nID";
                Label3.Content = "Subject";
                Label4.Content = "Book Name";
                Label5.Content = "ExamBoard\n(Lv)";
                Label6.Content = "Quantity\nOrdered";
                Label7.Content = "Total\nCost(£)";
                Label8.Content = "Book\nType";
                Label9.Content = "Date\nOrdered";
                Label10.Content = "Date\nRecieved";
                Label11.Content = "Notes";
                #endregion

                #region Database to Textbox inserting database Columns ito each textbox
                TextBox1.Text = sbO.OrderBooksId.ToString();
                TextBox2.Text = sbO.BookInventoryID.ToString();
                TextBox3.Text = sbO.Subject;
                TextBox4.Text = sbO.BookName;
                TextBox5.Text = sbO.ExamBoardAndLevel;
                TextBox6.Text =  sbO.QuantityOrdered.ToString();
                TextBox7.Text = Math.Round((Decimal)sbO.TotalCostOfBooks, 2).ToString();
                ComboBox8.ItemsSource = sbOrdersTest;
                ComboBox8.DisplayMemberPath = "BookType";
                ComboBox8.FontSize = 8;
                TextBox9.Text = sbO.DateOrdered.ToString();
                TextBox10.Text = sbO.DateOrderRecieved.ToString();
                TextBox11.Text = sbO.Notes;
                #endregion

                #region textboxes are ReadOnly
                TextBox1.IsReadOnly = true;
                TextBox2.IsReadOnly = true;
                TextBox3.IsReadOnly = true;
                TextBox4.IsReadOnly = true;
                TextBox5.IsReadOnly = true;
                TextBox6.IsReadOnly = true;
                TextBox7.IsReadOnly = true;
                ComboBox8.IsReadOnly = true;
                TextBox9.IsReadOnly = true;
                TextBox10.IsReadOnly = true;
                TextBox11.IsReadOnly = true;
                #endregion


            }
        }

        private void ListViewInventorySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var db = new SchoolBooksDBEntities()) 
            {
                sbInventoryTest = db.SBInventories.ToList();  
            }


                sbIn = (SBInventory)ListViewInventory.SelectedItem;
            if (sbIn != null)
            {
                AddButton.IsEnabled = true;
                EditButton.IsEnabled = true;
                DeleteButton.IsEnabled = true;

                #region label Content Name Change
                Label1.Content = "Inventory\nID";
                Label2.Content = "Subject";
                Label3.Content = "Book\nName";
                Label4.Content = "ExamBoard\n(Lv)";
                Label5.Content = "Book\nType";
                Label6.Content = "Quantity\nInStock";
                Label7.Content = "Notes";
                Label8.Content = "Book\nStatus";

                #endregion

                #region Database to Textbox inserting database Columns ito each textbox
                TextBox1.Text = sbIn.BookInventoryId.ToString();
                TextBox2.Text = sbIn.Subject;
                TextBox3.Text = sbIn.BookName;
                TextBox4.Text = sbIn.ExamBoardAndLevel;
                TextBox5.Text = sbIn.BookType;
                TextBox6.Text = sbIn.QuantityInStock.ToString();
                TextBox7.Text = sbIn.Notes;
                ComboBox8.ItemsSource = sbInventoryTest;
                ComboBox8.DisplayMemberPath = "BookSatus";
                ComboBox8.FontSize = 8;
                
                #endregion

                #region textboxes are ReadOnly
                TextBox1.IsReadOnly = true;
                TextBox2.IsReadOnly = true;
                TextBox3.IsReadOnly = true;
                TextBox4.IsReadOnly = true;
                TextBox5.IsReadOnly = true;
                TextBox6.IsReadOnly = true;
                TextBox7.IsReadOnly = true;
                ComboBox8.IsReadOnly = true;
                TextBox9.IsReadOnly = true;
                TextBox10.IsReadOnly = true;
                TextBox11.IsReadOnly = true;
                #endregion

                #region Empty labels and textboxes not being used
                Label9.Content = "";
                Label10.Content = "";
                Label11.Content = "";
                TextBox9.Text = "";
                TextBox10.Text = "";
                TextBox11.Text = "";
                #endregion

                
            }
        }

       
    }

    #region public classes to populate database tables by assigning public properties {get; set;} to their respected columns
    public class Students
    {
        public int studentId { get; set; }
        public int orderBooksId { get; set; }
        public string firstName{get; set;}
        public string lastName { get; set; }
        public int schoolYear { get; set; }
        public string subjects { get; set; }
        public string examBoardLv { get; set;}
        public bool booksCollected { get; set; }
        public string bookStatus { get; set; }


    }

    public class SchoolBookOrders 
    {
        public int orderBookId { get; set; }
        public int bookInventoryId { get; set; }
        public string subject { get; set; }
        public string bookName { get; set; }
        public string examBoard { get; set; }
        public string bookType { get; set; }
        public int quantyOrder { get; set; }
        public double totalCost { get; set; }
        public DateTime dateOrdered { get; set; }
        public DateTime dateOrderResieved { get; set; }
        public string notes { get; set; }

    }

    public class SchoolBooksInventory
    {
        public int bookInventoryId { get; set; }
        public string subject { get; set; }
        public string bookInventoryName{ get; set; }
        public string examBoardLevel { get; set; }
        public string bookType { get; set; }
        public string bookStatus { get; set; }
        public int quantityInStock { get; set; }
        public string Notes { get; set; }
    }
    #endregion
}

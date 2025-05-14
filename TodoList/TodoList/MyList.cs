using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    //Add, Count, index..based on the type...
    internal class MyList<T>
    {
        private readonly object get;

        public T[] Items { get; set; }
        public T[] NewItems { get; set; }
        public MyList()
        {
            Items = new T[0];
        }

        public void Add(T item)
        {
            if (Items.Length == 0)
            {
                Items = new T[1];
                Items[0] = item;
            } else
            {
                int ArrayLength = Items.Length;
                NewItems = new T[ArrayLength + 1];

                int count = 0;
                foreach (var item1 in Items)
                {
                    NewItems[count] = item1;
                    count++;
                }

                NewItems[NewItems.Length - 1] = item;
                Items = NewItems;
            }
        }

        public void Clear()
        {
            Items = new T[0];
        }
   
        public int Count//Bu bir method degil...sadece readonly bir property....dir unutma...
        {
            get {return Items.Length; }
        }

        //Sadece, listelme aslinda okumaislemi yapilacak...dolayisi ile
        public T[] MyItems 
        {
            get
            {
                return Items;
            }
        }

        //Items[index] get-set
        //this dedgimz bu class tan olusturulms olan instance..i temsil ediyor yani bu disarda direk olarak su sekilde kullanilablir=> MyList<string> list = new MyList<string>();  list[0]="Skien"; Console.WriteLine(list[0]);..
        public T this[int index]
        {
            get { return Items[index]; }
            set { Items[index] = value; }
        }

    }
    //Where ile yaptigmz islemlerde IEnumerable doner, bu da array tipine uygundur ama saa
}

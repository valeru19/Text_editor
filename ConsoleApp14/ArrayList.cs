using System;

namespace ConsoleApp
{
    public class ArrayList<T> : BaseList<T> where T : IComparable<T>
    {
        private T[] buffer;
        private int count;

        // Новый уровень массива
        private ArrayList<T>[] levels;

        public ArrayList()
        {
            buffer = new T[4];
            count = 0;
            levels = new ArrayList<T>[4];
        }

        public override int Count => count;

        public override void Add(T item)
        {
            if (count == buffer.Length)
            {
                Resize(buffer.Length * 2);
            }
            buffer[count] = item;
            levels[count] = new ArrayList<T>(); // Инициализация нового уровня для новой ячейки
            count++;
            OnChange();
        }

        public override void Insert(int pos, T item)
        {
            if (pos < 0 || pos > count)
            {
                throw new BadIndexException("Position is out of range");
            }

            if (count == buffer.Length)
            {
                Resize(buffer.Length * 2);
            }

            for (int i = count; i > pos; i--)
            {
                buffer[i] = buffer[i - 1];
                levels[i] = levels[i - 1];
            }

            buffer[pos] = item;
            levels[pos] = new ArrayList<T>(); // Инициализация нового уровня для вставленной ячейки
            count++;
            OnChange();
        }

        public override void Delete(int pos)
        {
            if (pos < 0 || pos >= count)
            {
                throw new BadIndexException("Position is out of range");
            }

            for (int i = pos; i < count - 1; i++)
            {
                buffer[i] = buffer[i + 1];
                levels[i] = levels[i + 1];
            }

            buffer[count - 1] = default(T);
            levels[count - 1] = null;
            count--;
            OnChange();
        }

        public override void Clear()
        {
            buffer = new T[4];
            levels = new ArrayList<T>[4];
            count = 0;
            OnChange();
        }

        public override int Find(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (buffer[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public override T this[int i]
        {
            get
            {
                if (i < 0 || i >= count)
                {
                    throw new BadIndexException("Index is out of range");
                }
                return buffer[i];
            }
            set
            {
                if (i < 0 || i >= count)
                {
                    throw new BadIndexException("Index is out of range");
                }
                buffer[i] = value;
                OnChange();
            }
        }

        public override void SaveToFile(string fileName)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName))
            {
                for (int i = 0; i < count; i++)
                {
                    file.WriteLine(buffer[i]);
                }
            }
        }

        public override void LoadFromFile(string fileName)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(fileName);
                buffer = new T[lines.Length];
                levels = new ArrayList<T>[lines.Length];
                count = 0;
                foreach (string line in lines)
                {
                    Add((T)Convert.ChangeType(line, typeof(T)));
                }
            }
            catch (Exception ex)
            {
                throw new BadFileException(ex.Message);
            }
        }

        public override void PrintList()
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(buffer[i] + " ");
                if (levels[i] != null)
                {
                    Console.Write("[");
                    levels[i].PrintList();
                    Console.Write("]");
                }
            }
            Console.WriteLine();
        }

        public void AddLevel()
        {
            for (int i = 0; i < count; i++)
            {
                levels[i] = new ArrayList<T>();
            }
        }

        private void Resize(int newSize)
        {
            T[] newBuffer = new T[newSize];
            ArrayList<T>[] newLevels = new ArrayList<T>[newSize];
            Array.Copy(buffer, newBuffer, count);
            Array.Copy(levels, newLevels, count);
            buffer = newBuffer;
            levels = newLevels;
        }
    }
}


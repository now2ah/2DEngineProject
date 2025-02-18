using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _2DEngineProject._2DEngineProject
{
    class DynamicArray
    {
        protected Object[] objects = new Object[3];
        protected int _curIndex = 0;
        protected int _size = 0;

        public int Size
        {
            get
            {
                return _size;
            }
        }

        public Object this[int index]
        {
            get
            {
                return objects[index];
            }
            set
            {
                if (index < objects.Length)
                {
                    objects[index] = value;
                }
            }
        }

        public DynamicArray()
        {

        }

        ~DynamicArray()
        {

        }

        //objects
        //[1][2][3]
        // ^  ^  ^  ^
        //newObjects
        //[1][2][3][][][]
        //          ^
        //objects <- newObjects 
        //[1][2][3][4][][]
        //          ^
        public void Add(Object inObject)
        {
            if (_curIndex >= objects.Length)
            {
                Reallocation();
            }

            objects[_curIndex] = inObject;
            _curIndex++;
            _size = _curIndex;
        }

        public void Insert(int insertIndex, Object value)
        {
            if (insertIndex >= _size)
                return;

            if (_size == objects.Length)
                Reallocation();

            _size++;

            for (int i = _size; i > insertIndex; i--)
            {
                objects[i] = objects[i - 1];
            }

            objects[insertIndex] = value;
        }

        //[][][][][]
        public void Remove(Object removeObject)
        {
            int travasalIndex = 0;

            //don't do this (comparing two reference type)
            //while (objects[travasalIndex] != removeObject)
            while (objects[travasalIndex].Equals(removeObject))
            {
                travasalIndex++;

                if (travasalIndex >= Size)
                    return;
            }

            for (int i=travasalIndex; i<Size-1; i++)
            {
                objects[i] = objects[i + 1];
            }

            _size--;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Size)
                return;

            int travasalIndex = index;
            for (int i = travasalIndex; i < Size - 1; i++)
            {
                objects[i] = objects[i + 1];
            }

            _size--;
        }

        public void Reallocation()
        {
            Object[] newArray = new Object[objects.Length * 2];
            for (int i=0; i<_size; i++)
            {
                newArray[i] = objects[i];
            }
            objects = newArray;
        }
    }
}

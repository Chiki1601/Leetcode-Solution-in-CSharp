public class Solution {
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K)
        {
            List<Tuple<int, int>>[] graph = new List<Tuple<int, int>>[n];
            MinHeap<int> heap = new MinHeap<int>();

            for (int i = 0; i < n; i++)
                graph[i] = new List<Tuple<int, int>>();

            for (int i = 0; i < flights.Length; i++)
                graph[flights[i][0]].Add(new Tuple<int, int>(flights[i][1], flights[i][2]));

            heap.Add(src, 0);

            while (heap.Count != 0)
            {
                HeapNode<int> cur = heap.ExtractHeapNode();

                if (cur.Key % 1000 == dst)
                    return cur.Weight;

                if (cur.Key / 1000 <= K)
                    foreach (var node in graph[cur.Key % 1000])
                        if (heap.Contains((cur.Key / 1000 + 1) * 1000 + node.Item1) && heap[(cur.Key / 1000 + 1) * 1000 + node.Item1].Weight > node.Item2 + cur.Weight)
                            heap.Decrease((cur.Key / 1000 + 1) * 1000 + node.Item1, node.Item2 + cur.Weight);
                        else if (!heap.Contains((cur.Key / 1000 + 1) * 1000 + node.Item1))
                            heap.Add((cur.Key / 1000 + 1) * 1000 + node.Item1, node.Item2 + cur.Weight);
            }

            return -1;
        }
}

    class MinHeap<T>
    {
        private List<HeapNode<T>> _data = new List<HeapNode<T>>();
        private Hashtable _hash = new Hashtable();

        public int Count
        {
            get
            {
                return _data.Count;
            }
        }

        public HeapNode<T> this[T item]
        {
            get
            {
                if (!_hash.ContainsKey(item))
                    return null;

                return _data[(int)_hash[item]];
            }
        }

        public bool Contains(T item)
        {
            return _hash.ContainsKey(item);
        }

        public void Add(T item, int weight)
        {
            _data.Add(new HeapNode<T>(item, weight));
            _hash.Add(item, _data.Count - 1);

            MinHeapify(_data.Count - 1);
        }

        public void Decrease(T item, int weight)
        {
            if (!_hash.ContainsKey(item))
                return;

            _data[(int)_hash[item]].Weight = weight;

            MinHeapify((int)_hash[item]);
        }

        public void Increase(T item, int weight)
        {
            if (!_hash.ContainsKey(item))
                return;

            _data[(int)_hash[item]].Weight = weight;

            MinHeapify((int)_hash[item], _data.Count - 1);
        }

        public HeapNode<T> PeekHeapNode()
        {
            return _data.Count != 0 ? _data[0] : null;
        }

        public T PeekKey()
        {
            return PeekHeapNode().Key;
        }

        public int PeekWeight()
        {
            return PeekHeapNode().Weight;
        }

        public HeapNode<T> ExtractHeapNode()
        {
            if (_data.Count == 0)
                return null;

            HeapNode<T> min = _data[0];
            _data[0] = _data[_data.Count - 1];
            _data.RemoveAt(_data.Count - 1);

            _hash.Remove(min.Key);

            MinHeapify(0, _data.Count - 1);

            return min;
        }

        public T ExtractKey()
        {
            return ExtractHeapNode().Key;
        }

        public int ExtractWeight()
        {
            return ExtractHeapNode().Weight;
        }

        // Heapify the data collection from current index to top.
        private void MinHeapify(int index)
        {
            while (index >= 0 && _data[(index - 1) / 2].Weight > _data[index].Weight)
            {
                Swap((index - 1) / 2, index);

                index = (index - 1) / 2;
            }
        }

        // Heapify the data collection from current index to bottom.
        private void MinHeapify(int index, int end)
        {
            int smallestIndex,
                leftIndex = 2 * index + 1,
                rightIndex = 2 * index + 2;

            if (leftIndex <= end && _data[index].Weight > _data[leftIndex].Weight)
                smallestIndex = leftIndex;
            else
                smallestIndex = index;

            if (rightIndex <= end && _data[smallestIndex].Weight > _data[rightIndex].Weight)
                smallestIndex = rightIndex;

            if (smallestIndex != index)
            {
                Swap(smallestIndex, index);

                MinHeapify(smallestIndex, end);
            }
            else
                for (int i = index; i <= end; i++)
                    _hash[_data[i].Key] = i;
        }

        private void Swap(int index1, int index2)
        {
            HeapNode<T> temp = _data[index1];
            _data[index1] = _data[index2];
            _data[index2] = temp;

            if (!_hash.ContainsKey(_data[index1].Key))
                _hash.Add(_data[index1].Key, index1);
            else
                _hash[_data[index1].Key] = index1;

            if (!_hash.ContainsKey(_data[index2].Key))
                _hash.Add(_data[index2].Key, index2);
            else
                _hash[_data[index2].Key] = index2;
        }
    }

    public class HeapNode<T>
    {
        public T Key;
        public int Weight;

        public HeapNode(T key, int weight)
        {
            this.Key = key;
            this.Weight = weight;
        }
    }

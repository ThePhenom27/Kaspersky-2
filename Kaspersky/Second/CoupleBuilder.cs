using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaspersky
{
    class CoupleBuilder
    {
        private List<int> _numbers;
        public CoupleBuilder(List<int> numbers) {
            _numbers = numbers;
        }
        public CoupleBuilder(params int[] numbers) 
        {
            _numbers = numbers.ToList();
        }
        public List<Tuple<int, int>> BuildWithSum(int sum) {
            var ret = new List<Tuple<int, int>>();

            _numbers.Sort();

            int iFirst, iSecond;
            for (iFirst = 0; iFirst < _numbers.Count; iFirst++) {
                if (_numbers[iFirst] >= sum) break;
                for (iSecond = iFirst + 1; iSecond < _numbers.Count; iSecond++) {
                    int currentSum = _numbers[iFirst] + _numbers[iSecond];
                    if (currentSum == sum) {
                        ret.Add(new Tuple<int, int>(_numbers[iFirst], _numbers[iSecond]));
                        _numbers.RemoveAt(iSecond);
                        _numbers.RemoveAt(iFirst);
                        iSecond -= 2;
                        iFirst -= 1;
                        break;

                    }
                }
            }
            return ret;
        }
    }
}

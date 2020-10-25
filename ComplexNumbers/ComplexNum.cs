using System;

namespace ComplexNumbers
{
    public class ComplexNum
    {
        public int RealPart { get; private set; }
        public int ImgPart { get; private set; }

        public ComplexNum(int rp, int ip)
        {
            RealPart = rp;
            ImgPart = ip;
        }
        public ComplexNum()
        {
 
        }

        public ComplexNum Add(ComplexNum num)
        {
           return new ComplexNum(RealPart + num.RealPart, ImgPart + num.ImgPart);
        }

        public ComplexNum Sub(ComplexNum num)
        {
            return new ComplexNum(RealPart - num.RealPart, ImgPart - num.ImgPart);
        }

        public ComplexNum Mult(ComplexNum num)
        {
            int rp1 = RealPart * num.RealPart - ImgPart * num.ImgPart;
            int ip1 = RealPart * num.ImgPart + num.RealPart * ImgPart;
            return new ComplexNum(rp1, ip1);
        }

        public void Print(int lineParam)
        {
            if(lineParam==0)
            {
                if(RealPart !=0)
                Console.Write(RealPart);
                if (ImgPart > 0)
                    Console.Write($"+{ImgPart}i");
                else if (ImgPart < 0)
                    Console.Write($"{ImgPart}i");

            }
            else
            {
                if (RealPart != 0)
                    Console.Write(RealPart);
                if (ImgPart > 0)
                    Console.WriteLine($"+{ImgPart}i");
                else if (ImgPart < 0)
                    Console.WriteLine($"{ImgPart}i");
            }
        }

    }
}
using System;
public class InterlacedSpiralCipher
{
  public static string Encode(string s)
        { 
            int offset = Convert.ToInt32(Math.Ceiling(Math.Sqrt(s.Length)));

            s = s.PadRight(offset * offset);

            char[] str = new char[offset * offset];
            char[,] c = new char[offset, offset];
            int k = 0;

            int top = 0;
            int left = 0;
            int bot = offset - 1;
            int right = offset - 1;
            int totalRings = (offset + 1) / 2;

            for (int ring = 0; ring < totalRings; ring++)
            {
                top = ring;
                left = ring;
                right = offset - 1 - ring;
                bot = offset - 1 - ring;
                for (int i = 0; i < right - ring; i++)
                {
                    c[top, left + i] = s[k++];
                    c[top + i, right] = s[k++];
                    c[bot, right - i] = s[k++];
                    c[bot - i, left] = s[k++];
                }
                if (right == ring) c[top, left] = s[k++];
            }

            k = 0; 
            for (int i = 0; i < offset; i++) 
                for (int j = 0; j < offset; j++)
                {
                    if (!Char.IsWhiteSpace(c[i, j]))
                        str[k++] = c[i, j];
                    else str[k++] = Convert.ToChar(" ");
                }

            return new string(str);
        }
        public static string Decode(string s)
        {
            int length = s.Length;
            int offset = Convert.ToInt32(Math.Sqrt(length));
            char[] str = new char[offset * offset];
            char[,] c = new char[offset, offset];
            int k = 0;

            int top = 0;
            int left = 0;
            int bot = offset - 1;
            int right = offset - 1;
            int totalRings = (offset + 1) / 2;

            k = 0;
            for (int i = 0; i < offset; i++)
                for (int j = 0; j < offset; j++)
                    c[i, j] = s[k++];

            k = 0;
            for (int ring = 0; ring < totalRings; ring++)
            {
                top = ring;
                left = ring;
                right = offset - 1 - ring;
                bot = offset - 1 - ring;
                for (int i = 0; i < right - ring; i++)
                {
                    str[k++] = c[top, left + i];
                    str[k++] = c[top + i, right];
                    str[k++] = c[bot, right - i];
                    str[k++] = c[bot - i, left];
                }
                if (right == ring) str[k++] = c[top, left];
            }

            return new string(str).TrimEnd();
        }
}

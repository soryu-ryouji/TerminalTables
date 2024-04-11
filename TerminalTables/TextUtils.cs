namespace TerminalTables;

public class TextUtils
{
    public static int GetCharWidth(char ch)
    {
        if (ch > 127)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }

    public static int GetLineWidth(string line)
    {
        if (line == "") return 0;

        var length = line.ToCharArray().Sum(GetCharWidth);
        return length;
    }

    public static List<string> WarpLine(int width, string line)
    {
        var warpLines = new List<string>();

        int curWidth = 0;
        int splitPos = 0;
        for (int i = 0; i < line.Length; i++)
        {
            var charWidth = GetCharWidth(line[i]);
            curWidth += charWidth;

            if (curWidth >= width)
            {
                var split = line[splitPos..(i+1)];
                warpLines.Add(split);
                splitPos = i + 1;
                curWidth = 0;
            }
        }
        warpLines.Add(line[splitPos..]);

        return warpLines;
    }
}
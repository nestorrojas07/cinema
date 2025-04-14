namespace Application.Utils;

public static class HallLocationUtil
{
    private static string  alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
    public static string getLocationByColumnAndRow(int column, int row)
    {
        return  $"{numberToString(column)} {row}";

    }
    
    private static string numberToString(int number)
    {
        if (number < 0 || number >= alphabet.Length)
            throw new ArgumentOutOfRangeException("Row out of range");
        
        return $"{alphabet[number]}";
    }
    
}
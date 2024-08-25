using System.Collections.Generic;

namespace MyApi.Models  // Adjust the namespace according to your project structure
{
public class Item
{
    public string Label { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public string BgColor { get; set; } = string.Empty;
    public string TextColor { get; set; } = string.Empty;
}

public class Section
{
    public string Title { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public List<Item> Items { get; set; } = new List<Item>();
}

}
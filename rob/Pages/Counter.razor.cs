using Microsoft.AspNetCore.Components;

namespace rob.Pages{
    public partial class Counter
    {
    int currentCount = 0;

        void IncrementCount()
        {
            currentCount++;
        }
         [Parameter]
    public string Text { get; set; }

    }
}

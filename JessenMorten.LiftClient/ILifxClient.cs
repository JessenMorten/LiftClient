using System.Collections.Generic;
using System.Threading.Tasks;
using JessenMorten.Lifx.Models;

namespace JessenMorten.LiftClient
{
    public interface ILifxClient
    {
        Task BreatheAsync(LifxBulb bulb, string color, string fromColor = null, int cycles = 3, double period = 1);

        Task<IEnumerable<LifxBulb>> GetAllAsync();

        Task PulseAsync(LifxBulb bulb, string color, string fromColor = null, int cycles = 3, double period = 1);

        Task SetColorAsync(LifxBulb bulb, string color);

        Task SetStateAsync(LifxBulb bulb, string color = null, bool on = true, double brightness = 1, double duration = 1);

        Task StopEffectsAsync(LifxBulb bulb);

        Task TogglePowerAsync(LifxBulb bulb);

        Task TurnOffAsync(LifxBulb bulb);

        Task TurnOnAsync(LifxBulb bulb);
    }
}

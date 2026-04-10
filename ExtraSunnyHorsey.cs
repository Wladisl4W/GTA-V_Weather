using GTA;
using GTA.Native;
using System;

namespace ExtraSunnyHorsey
{
    public class ExtraSunnyHorseyScript : Script
    {
        public ExtraSunnyHorseyScript()
        {
            Tick += OnTick;
        }

        private void OnTick(object sender, EventArgs e)
        {
            // Выгружаем все текущие cloud hats
            Function.Call(Hash.UNLOAD_ALL_CLOUD_HATS);

            // LOAD_CLOUD_HAT одновременно загружает И активирует cloud hat
            // Второй параметр — время плавного перехода в секундах (0.0f = мгновенно)
            // Внимание: имя чувствительно к регистру — "Horsey", а не "HORSEY"
            Function.Call(Hash.LOAD_CLOUD_HAT, "Horsey", 1.0f);

            // Устанавливаем погоду
            Function.Call(Hash.SET_WEATHER_TYPE_NOW_PERSIST, "EXTRASUNNY");

            // Отписываемся, чтобы не вызывать каждый кадр
            Tick -= OnTick;
        }
    }
}

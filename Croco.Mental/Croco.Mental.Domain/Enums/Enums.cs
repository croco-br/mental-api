using System;
using System.Collections.Generic;
using System.Text;

namespace Croco.Mental.Domain.Enums
{
    /// <summary>
    /// Gender neutral emotion definition.
    /// </summary>
    public enum MoodDefinition
    {
        Interessadx = 0,
        Nervosx = 1,
        Entusiasmadx = 2,
        Amedrontadx = 3,
        Inspiradx = 4,
        Ativx = 5,
        Assustadx = 6,
        Culpadx = 7,
        Determinadx = 8,
        Atormentadx = 9
    }

    /// <summary>
    /// Level of emotions.
    /// </summary>
    public enum MoodLevel
    {
        Nada = 1,
        Pouco = 2,
        Moderadamente = 3,
        Bastante = 4,
        Extremamente = 5
    }

    /// <summary>
    /// Possible Genders.
    /// </summary>
    public enum Gender
    {
        Masculine = 1,
        Feminine = 2,
        Agender = 3,
        Transgender = 4
    }
}

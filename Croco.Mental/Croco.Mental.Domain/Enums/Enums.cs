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
        Nervosx = 1,
        Interessadx = 2,
        Amedrontadx = 3,
        Entusiasmadx = 4,
        Inspiradx = 5,
        Assustadx = 6,
        Culpadx = 7,
        Ativx = 8,
        Atormentadx = 9,
        Determinadx = 10,
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

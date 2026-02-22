using System;

namespace GuessTheWord
{
    public class CansoleUI
    {
        public char InputLetter()
        {
            var result = Console.ReadLine();
            return result[0];
        }

        public DifficultyType ChooseDifficulty()
        {
            // вывести сообщение пользователю, что бы он выбрал сложность
            // прочитать его выбор 
            // опционально - добавить проверку ввода
            // преобразовать его ввод в тип enum и вернуть значение
            return DifficultyType.Easy;
        }
    }
}
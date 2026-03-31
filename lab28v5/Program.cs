using lab28v5.Models;
using lab28v5.Repositories;

var repo = new SongRepository();
string file = "songs.json";

// Додаємо дані
var artist = new Artist { Id = 1, Name = "Queen", Genre = "Rock" };
repo.Add(new Song { Id = 1, Title = "Bohemian Rhapsody", DurationSeconds = 354, Artist = artist });
repo.Add(new Song { Id = 2, Title = "Don't Stop Me Now", DurationSeconds = 209, Artist = artist });

// Зберігаємо
await repo.SaveToFileAsync(file);
Console.WriteLine("Дані збережено у JSON!");

// Завантажуємо в новий репозиторій
var newRepo = new SongRepository();
await newRepo.LoadFromFileAsync(file);

Console.WriteLine("Прочитано з файлу:");
foreach (var s in newRepo.GetAll())
{
    Console.WriteLine($"{s.Title} - {s.Artist?.Name}");
}
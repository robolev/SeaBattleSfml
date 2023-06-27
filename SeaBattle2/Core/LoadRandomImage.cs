﻿using SFML.Graphics;

namespace Agario;

public class LoadRandomImage
{
    public Texture LoadRandomImageFromFile(string directoryPath)
    {
        string path  = Path.Combine(Directory.GetCurrentDirectory(), directoryPath);
            
        string[] spriteFiles = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory (), path));
        spriteFiles = spriteFiles.Where(x => x.EndsWith(".png") || x.EndsWith("jpg")).ToArray();
        
        if (spriteFiles.Length == 0)
        {
            throw new Exception("No sprite sheets found in the specified directory.");
        }

        Random random = new Random();
        string randomSpriteFile = spriteFiles[random.Next(0, spriteFiles.Length)];

        Texture spriteSheet = new Texture(randomSpriteFile);
        return spriteSheet;
    }
}
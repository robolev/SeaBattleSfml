using Agario;

namespace SeaBattle2;

public interface Iscene:IDrawable,IUpdatable
{
    public void Load();

    public void Unload();
}


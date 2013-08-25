using UnityEngine;
using System.Collections;
 
public class SpriteSheet : MonoBehaviour
{
	/*public bool IsAnimating
	{
		get {return animating;}
	}*/
    public int columns = 2;
    public int rows = 2;
    public float framesPerSecond = 10f;
	bool loop = false;
	public bool animate = false;
 
    //the current frame to display
    private int index = 0;
	private float tick = 0;
	private bool animating = false;
	
	
 
    void Start()
    {
        //set the tile size of the texture (in UV units), based on the rows and columns
        Vector2 size = new Vector2(1f / columns, 1f / rows);
        renderer.material.SetTextureScale("_MainTex", size);
		index = -1;
    }
	
	private void Animate (float _tick)
	{
		if(_tick/(index+1) > framesPerSecond)
		{
		    index++;
	        if (index >= rows * columns)
	            index = 0;
			
	        //split into x and y indexes
	        Vector2 offset = new Vector2((float)index / columns - (index / columns), //x index
	                                      (index / columns) / (float)rows);          //y index
	        renderer.material.SetTextureOffset("_MainTex", offset);
		}
	}
	
	protected void Reset ()
	{
		index = -1;
		tick = 0;
		animate = false;
	}
	
	protected void Update()
	{
		if(animate)
		{
			if(loop || tick < (rows*columns)/framesPerSecond)
			{
				tick += Time.deltaTime;
			}
			Animate(tick);
		}
	}
}
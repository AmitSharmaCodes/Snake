using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParSys : MonoBehaviour {

	// Use this for initialization

    public static bool particleNumberChanged = false;
    public static int particleCount = 0;
    public static ParSys system;

    public int numberOfParticles = 2; 
   
    Mesh mesh;
    List<MParticle> parts;

    Vector3[] verts;
    Vector2[] uvs;
    Color[] colors;
    int[] triangle;

    int particleMax;


    void Awake() {
        
        if (system == null)
        {
            system = this;
            InitList();
            gameObject.AddComponent<MeshFilter>();
            mesh = GetComponent<MeshFilter>().mesh;
            mesh.MarkDynamic();

        }
        else if(system != this)
            Destroy(gameObject);
    }

	// Update is called once per frame
	void Update () {
        foreach (MParticle m in parts)
            m.Update();

        UpdateMesh();
    }

    //in the middle of changing all the lists to arrays
    // you only need to change the uvs, and triangles if there is a new max
    // you need to change colors if there is a change in particles, removed or added
    // pos undated every frame
    // if there are extra verts, then make them all pos zero, and zero alpha, take care of this when particles disappear

    void UpdateMesh()
    {
        if(particleNumberChanged)
        {
          //  mesh.Clear();
            particleNumberChanged = false;
            if(particleCount > particleMax)
            {
                //rebuild verts, uvs, colors, and triangle to new max
                ExpandArrays(particleMax, particleCount);
                particleMax = particleCount;
                //update position and color data
                FillArrays();
                // rebuild uvs and triangle data
                FillUVAndTri(particleCount);
            

            }
            else
            {
                // change pos, and color, and new triangle count to be correct
                FillArrays();
                FillUVAndTri(particleCount);
            }
            mesh.vertices = verts;
            mesh.uv = uvs;
            mesh.colors = colors;
            mesh.triangles = triangle;

        } else  // no particles changed, update pos, and color, no need to alpha zero anything
        {
            FillArrays();
            mesh.vertices = verts;
            mesh.colors = colors;

        }
    }
    void FillArrays()
    {
        int count = 0;
        foreach(MParticle m in parts)
            if(m.isActive){
            ChangeVertPoint(m.position,m.size, count);
            ChangeColor(m.color, count);
            count++;
        }
    }

    void FillUVAndTri(int count){
        int[] tempTri = new int[count * 6];
        for (int i = 0; i < count; i++)
        {
            int indice = i * 4;
            int indice2 = i * 6;

            Vector2 temp = uvs[indice];
            temp.x = 0;
            temp.y = 0;
            uvs[indice] = temp;

            temp = uvs[indice + 1];
            temp.x = 0;
            temp.y = 1;
            uvs[indice + 1] = temp;

            temp = uvs[indice + 2];
            temp.x = 1;
            temp.y = 1;
            uvs[indice + 2] = temp;

            temp = uvs[indice + 3];
            temp.x = 1;
            temp.y = 0;
            uvs[indice + 3] = temp;

            tempTri[indice2] = indice;
            tempTri[indice2 + 1] = indice + 1;
            tempTri[indice2 + 2] = indice + 2;
            tempTri[indice2 + 3] = indice + 2;
            tempTri[indice2 + 4] = indice + 3;
            tempTri[indice2 + 5] = indice;

        }
        triangle = tempTri;
    }
   void ExpandArrays(int expandFrom, int expandTo){
        Vector3[] vertTemp = new Vector3[expandTo * 4];
        Vector2[] uvsTemp = new Vector2[expandTo * 4];
        Color[] colorsTemp = new Color[expandTo * 4];
        int[] triangleTemp = new int[expandTo * 6];
   //     Debug.Log("EXPAND FROM = " + expandFrom + " to " + expandTo);
        for (int i = 0; i < expandFrom; i++)
        {
            int indice = i * 4;
            int indice2 = i * 6;
            //verts
            vertTemp [indice] = verts[indice];
            vertTemp [indice + 1] = verts[indice + 1];
            vertTemp [indice + 2] = verts[indice + 2];
            vertTemp [indice + 3] = verts[indice + 3];

            uvsTemp [indice] = uvs [indice];
            uvsTemp [indice + 1] = uvs[indice + 1];
            uvsTemp [indice + 2] = uvs[indice + 2];
            uvsTemp [indice + 3] = uvs[indice + 3];

            colorsTemp [indice] = colors [indice];
            colorsTemp [indice + 1] = colors [indice + 1];
            colorsTemp [indice + 2] = colors [indice + 2];
            colorsTemp [indice + 3] = colors [indice + 3];

            triangleTemp [indice2] = triangle [indice2];
            triangleTemp [indice2 + 1] = triangle [indice2 + 1];
            triangleTemp [indice2 + 2] = triangle [indice2 + 2];
            triangleTemp [indice2 + 3] = triangle [indice2 + 3];
            triangleTemp [indice2 + 4] = triangle [indice2 + 4];
            triangleTemp [indice2 + 5] = triangle [indice2 + 5];
        }
        for (int i = expandFrom; i < expandTo; i++)
        {
            int indice = i * 4;
            int indice2 = i * 6;
            //verts
            vertTemp [indice] = new Vector3();
            vertTemp [indice + 1] = new Vector3();
            vertTemp [indice + 2] = new Vector3();
            vertTemp [indice + 3] = new Vector3();
            
            uvsTemp [indice] = new Vector3();
            uvsTemp [indice + 1] = new Vector2();
            uvsTemp [indice + 2] = new Vector2();
            uvsTemp [indice + 3] = new Vector2();
            
            colorsTemp [indice] = new Color();
            colorsTemp [indice + 1] = new Color();
            colorsTemp [indice + 2] = new Color();
            colorsTemp [indice + 3] = new Color();
            
            triangleTemp [indice2] = 0;
            triangleTemp [indice2 + 1] = 0;
            triangleTemp [indice2 + 2] = 0;
            triangleTemp [indice2 + 3] = 0;
            triangleTemp [indice2 + 4] = 0;
            triangleTemp [indice2 + 5] = 0;
        }

        verts = vertTemp;
        uvs = uvsTemp;
        colors = colorsTemp;
        triangle = triangleTemp;
    }

    void ChangeVertPoint(Vector3 v, float size, int count){
        int indice = count * 4;

        Vector3 temp;
        temp = verts[indice];
        temp.x = v.x - .5f * size;
        temp.y = v.y -.5f * size;
        verts[indice] = temp;

        temp = verts[indice + 1];
        temp.x = v.x - .5f * size; 
        temp.y = v.y + .5f * size;
        verts [indice + 1] = temp;

        temp = verts[indice + 2];
        temp.x = v.x + .5f * size; 
        temp.y = v.y + .5f * size;
        verts [indice + 2] = temp;

        temp = verts[indice + 3];
        temp.x = v.x + .5f * size; 
        temp.y = v.y - .5f * size;
        verts [indice + 3] = temp;
    }
    void ChangeColor(Color c, int count){
        int indice = count * 4;
        colors [indice] = c;
        colors [indice + 1] = c;
        colors [indice + 2] = c;
        colors [indice + 3] = c;
    }

    void InitList()
    {
        ExpandArrays(0, numberOfParticles);
        particleMax = numberOfParticles;
        parts = new List<MParticle>();
        for (int i = 0; i < numberOfParticles * 4; i++)
        {
            MParticle m = new MParticle();
            m.isActive = false;
            parts.Add(m);
        }
    }
    MParticle GetParticle(){
        foreach (MParticle m in parts)
            if (!m.isActive)
                return m;
        MParticle part = new MParticle();
        parts.Add(part);
        return part;
    }

    public void StartExplosion(Vector3 pos, Color c){
        Color posCol = c;
        for(int i = 0; i < numberOfParticles; i++) {
            MParticle obj = GetParticle();
            posCol.r += Random.Range(-0.15f, 0.15f);
            posCol.b += Random.Range(-0.15f, 0.15f);
            posCol.g += Random.Range(-0.15f, 0.15f);
            obj.OnEnable(posCol, pos);
            particleNumberChanged = true;
        }
        particleCount += numberOfParticles;
    }

}

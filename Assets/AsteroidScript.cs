using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public GameObject asteroidExplosion;    //взрыв астероида
    public GameObject playerExplosion;      //взрыв игрока
    public float rotationSpeed;             //скорость вращения
    public float minSpeed, maxSpeed;        //границы скорости
    public float minSize, maxSize;          //размеры
    float size;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;
        float speed = Random.Range(minSpeed, maxSpeed);
        asteroid.velocity = new Vector3(0, 0, - speed); //задаём скорость
        size = Random.Range(minSize, maxSize);
        asteroid.transform.localScale *= size;          //задаём размер
    }

    // OnTriggerEnter is called in collision with object
    private void OnTriggerEnter(Collider other)
    {
        //Отсутствие взаимодействия
        if (other.tag == "Asteroid" || other.tag == "GameBoundary" || other.tag == "PowerUp")
            return;
        Destroy(gameObject);  
        GameObject explosion = Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
        explosion.transform.localScale *= size;
        //Уничтожение врага или выстрела
        if (other.tag == "Enemy" || other.tag == "LazerShot" || other.tag == "LazerEnemyShot")
        {
            Destroy(other.gameObject);
        }
    }
}

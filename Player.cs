using System.Threading;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private CharacterController controller;
    private float rot;
    private float rotSpeed;
    private Animator anima;
    public float gravity;
    public ParticleSystem efeitoDeParticulas;
    // Start is called before the first frame update
    void Start()
    {
        //atribuindo variaveis aos componentes adicionados no canhão
        controller = GetComponent<CharacterController>();
        anima = GetComponent<Animator>();
        //se eu não der um valor pra velocidade de rotação a velocidade vai ser 0 então não tem movimento
        rotSpeed = 50f;
        //tenho que definir o stop para que não começe atirando
        efeitoDeParticulas.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        Acoes();
    }
    void Acoes()
    {
            rot += Input.GetAxis("Horizontal")*rotSpeed*Time.deltaTime;
            transform.eulerAngles = new Vector3(0,rot,0);
           
            //O anima.Set vai atribuir ao parametro transition o valor da transicao
            //idle(parado)->0
            //descer->3
            //subir->4
            //atirar->5
            //cano do canhao desce
            if(Input.GetKey(KeyCode.S)){
                anima.SetInteger("transition",3);
            }
            if(Input.GetKeyUp(KeyCode.S)){
               anima.SetInteger("transition",0);
            }
            //cano do canhao sobe
            if(Input.GetKey(KeyCode.W)){
                anima.SetInteger("transition",4);
            }
            if(Input.GetKeyUp(KeyCode.W)){
               anima.SetInteger("transition",0);
            }
            //canhao atira
            if(Input.GetKeyDown(KeyCode.Space)){
                Atirar();
                //anima.SetInteger("transition",5);
                // Ativa o efeito de partículas quando o canhão atira
                efeitoDeParticulas.Play();
            }
            if(Input.GetKeyUp(KeyCode.Space)){
                //Thread.Sleep(200);
              anima.SetInteger("transition",0);
            }
    }
    void Atirar()
    {
        // Ativa o efeito de partículas quando o canhão atira
                efeitoDeParticulas.Play();
                anima.SetInteger("transition", 5);
                GetComponent<AudioSource>().Play();
    }
}

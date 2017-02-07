using UnityEngine;
using System.Collections;

public class MainPlayerInterface : MonoBehaviour
{
	//컴포넌트 제어 변수 계
    CharacterController charCtrl;
	AudioSource musicPlayer;
	public AudioClip[] auidioFile;
    Animator charAni;
        
    enum SEclip : byte  //소리가 있는 모션 목록
    {
        jump, hurt, attack, landing
    }
    enum CharStatus : byte  //상태이상 목록
    {
        normal, onHit, stun, freeze, slow
    }

    bool lookRightSide;  //좌우 주시 여부
    Vector3 lookVector;  //플레이어 주시 벡터
    public Vector3 moveVector = Vector3.zero;  //이동 예정 벡터    

    
    //플레이어 능력치 관련 변수들
    public float gravity;  //캐릭터 적용 중력
    public float moveSpeed;  //이동속도
    public float jumpPower;  //점프력
    public float JumpCount;  //점프 가능 횟수(초기설정값)
        public float canJumpCount;  //남은 점프 가능 횟수


    //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
    
	//스크립트 활성 여부에 관계 없이 호출되는 start 함수 계
    void Awake()
	{
        charCtrl = GetComponent<CharacterController>();  //컴포넌트 CharacterController 스크립트로 제어 준비	
        charAni = GetComponent<Animator>();  //컴포넌트 Animator 스크립트로 제어 준비
        lookRightSide = true;

        //기본 능력치, 환경 설정
        gravity = 20.0f;
        jumpPower = 10.0f;
        moveSpeed = 3.0f;
        JumpCount = 3;  canJumpCount = JumpCount;
    }
	
    //매 프레임 마다 호출 함수 계	
	void Update ()      
	{   
        //중력을 매 프레임(Time.deltaTime)에 가산적용 부
        moveVector.y -= gravity * Time.deltaTime;  //실제 중력 가속도 구현

        //캐릭터 움직임 최종 변경 부
        Vector3 globalDirection = transform.TransformDirection(moveVector);  //캐릭터 이동 : 글로벌 좌표축에 대해 이동 계산
        charCtrl.Move(globalDirection * Time.deltaTime);  //deltaTime을 이용하여 프레임 속도 차이의 영향을 완화

        //이동 후 처리(착지 처리)
        if (charCtrl.isGrounded)
        {
            moveVector.y = 0;  //낙하 속도 0 설정
            canJumpCount = JumpCount;  //점프 카운트 회복
            //playSE((byte)SEclip.landing);  //착지 효과음 재생
        }

        charAni.SetBool("isOnGrounded", charCtrl.isGrounded);  //공중 뜬 상태 감지 계
        //charAni.SetBool("isRunning", moveVector.x > 0.0f);  //이동 감지 계
    }
    
    //우측으로 가속 메소드
    public void goRight(float move)
	{
        //Debug.Log("force go Right");

        //회전 부
        if (move > 0 && !lookRightSide) // 우로 돌아(-->)
            Flip();
        
        //이동 시 '달리기' 애니메이션 적용 부
        charAni.SetFloat("speed", Mathf.Abs(move));  //스피드 값에 절대값(Abs 함수)을 씌워 에니메이터 인자에 전달

        //속도 변화(움직임)부
        /*
        if (charCtrl.isGrounded)  //땅에 착지한 상태인 경우
        {

        }
        */
        //Input의 Vertical 입력에 대해 이동 계산 부 
        if (move > 0)  //Vertical 입력 시
        {
            moveVector.z = move * moveSpeed;  //설정 이동속도 만큼 계산
        }
        else  //입력이 끊겨 값이 0 으로 복귀할 경우
        {
            moveVector.z = 0;  //이동 멈춤
        }
    }

    //좌측으로 가속 메소드
    public void goLeft(float move)
	{
        //Debug.Log("force go Left");        

        //회전 부
        if (move < 0 && lookRightSide)  // 좌로 돌아(<--)
            Flip();

        //이동 시 '달리기' 애니메이션 적용 부
        charAni.SetFloat("speed", Mathf.Abs(move));  //스피드 값에 절대값(Abs 함수)을 씌워 에니메이터 인자에 전달

        //속도 변화(움직임)부
        //Input의 Vertical 입력에 대해 이동 계산 부         
        if (move < 0)  //Vertical 입력 시
        {            
            moveVector.z = -1.0f * move * moveSpeed;  //설정 이동속도 만큼 계산
        }
        else  //입력이 끊겨 값이 0 으로 복귀할 경우
        {
            moveVector.z = 0;  //이동 멈춤
        }

    }

    //캐릭터 점프 메소드
    public void doJump()
    {
        //Debug.Log("force Jumping");


        //속도 변화(움직임)부
        if (charCtrl.isGrounded)  //땅에 착지한 상태인 경우
        {
            moveVector.y = jumpPower;
            charAni.SetTrigger("forceJump");
            canJumpCount--;
        }
        else if(!(charCtrl.isGrounded) && canJumpCount > 0)
        {            
            moveVector.y = jumpPower;
            charAni.SetTrigger("forceJump");
            canJumpCount--;
        }
    }

    //좌우방향 돌아보기 처리 메소드
    void Flip()
    {
        lookRightSide = !lookRightSide;
        Vector3 orderVector = transform.localScale;
        orderVector.z *= -1;
        transform.localScale = orderVector;
    }

    //캐릭터(효과음) 재생 메소드
    public void playSE(byte fileNum)
    {
        musicPlayer.clip = auidioFile [fileNum];
        musicPlayer.Play();
    }

    //통상공격 모션 메소드
    public void doNormalAttack()
    {

    }

    //어퍼어택 모션 메소드
    public void doUpperAttack()
    {

    }

    //찌르기공격 모션 메소드
    public void doStabAttack()
    {

    }

    //찍기공격 모션 메소드
    public void doChopDown()
    {

    }    

    //리타이어 처리 메소드
    public void retired()
    {

    }
}
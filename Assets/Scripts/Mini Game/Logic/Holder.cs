using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : Interactive
{
    public bool isEmpty;

    public HashSet<Holder> linkHolders = new HashSet<Holder>();

    public BallName matchBall;

    private Ball currentBall;


    public void CheckBall(Ball ball)
    {
        currentBall = ball;
        if(ball.ballDetails.ballName == matchBall)
        {
            currentBall.isMatch = true;
            currentBall.SetRinght();
        }
        else
        {
            currentBall.isMatch = false;
            currentBall.SetWrong();
        }
    }

    public override void EmptyClicked()
    {
        foreach (var holder in linkHolders)
        {
            if (holder.isEmpty)
            {
                // �ƶ���
                currentBall.transform.position = holder.transform.position;
                currentBall.transform.SetParent(holder.transform);

                // ������
                holder.CheckBall(currentBall);
                this.currentBall = null;

                // �ı�״̬
                this.isEmpty = true;
                holder.isEmpty = false;

                EventHandler.CallCheckGameStateEvent();
            }
        }
    }
}

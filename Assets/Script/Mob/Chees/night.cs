using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class night : CheesMob
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = MobPosition.getpositon();
        InvokeRepeating("atk1", 2f, 2f);
    }

    private void atk1() {
        RandMove();
    }
    protected IEnumerator delayatk1(float wait, Cp cp)
    {
        yield return new WaitForSeconds(wait);//time의 시간이후 아래의 코드를 실행
        Moveatk(cp, 0.5f);
    }
    protected IEnumerator delayatk2(float wait){
        yield return new WaitForSeconds(wait);
        List<Cp> movelist = new List<Cp>();
        List<Cp> removelist = new List<Cp>();
        movelist.Clear();
        removelist.Clear();
        for (int a = 1; a < 5; a++)
        {
            for (int b = 1; b < 4; b += 2)
            {
                movelist.Add(MobPosition + Cp.unitCp(a) * new Cp(2, 2) + Cp.unitCp(a + b));
            }
        }
        for (int c = 0; c < 8; c++)
        {
            if (!movelist[c].rangecheek())
            {
                removelist.Add(movelist[c]);
            }
        }
        for (int k = 0; k < removelist.Count; k++)
        {
            movelist.Remove(removelist[k]);
        }
        for (int j = 0; j < movelist.Count; j++) {
            atk(movelist[j]);
        }
    }

    private void RandMove() {
        List<Cp>movelist = new List<Cp>();
        List<Cp>removelist = new List<Cp>();
        movelist.Clear();
        removelist.Clear();
        for (int a = 1; a < 5; a++) {
            for (int b = 1; b < 4; b += 2) {
                movelist.Add(MobPosition + Cp.unitCp(a) * new Cp(2, 2) + Cp.unitCp(a+b));
            }
        }
        for (int c = 0; c < 8; c++) {
            if (!movelist[c].rangecheek()) {
                removelist.Add(movelist[c]);
            }
        }
        for (int k = 0; k < removelist.Count; k++) {
            movelist.Remove(removelist[k]);
        }
        Cp target = movelist[Random.Range(0, movelist.Count)];
        if (MobPosition.x + 2 == target.x)
        {
            Moveatk(MobPosition + Cp.unitCp(1), 0.5f);
            StartCoroutine(delayatk1(0.5f, target));
        }
        else if (MobPosition.y - 2 == target.y)
        {
            Moveatk(MobPosition + Cp.unitCp(2), 0.5f);
            StartCoroutine(delayatk1(0.5f, target));
        }
        else if (MobPosition.x - 2 == target.x)
        {
            Moveatk(MobPosition + Cp.unitCp(3), 0.5f);
            StartCoroutine(delayatk1(0.5f, target));
        }
        else
        {
            Moveatk(MobPosition + Cp.unitCp(4), 0.5f);
            StartCoroutine(delayatk1(0.5f, target));
        }
        StartCoroutine(delayatk2(1.1f));

    }
}
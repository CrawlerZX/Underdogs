using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public static List<Enemy_Script> enemy;

    private void Awake() {
        //Iniclializa a variavel, pois se não fizer isso ela fica como null e não vai ter como adicionar nada nela
        enemy = new List<Enemy_Script>();
    }

    /// <summary>
    /// Pega o inimigo mais próximo da possição que foi passada como referencia para esse método.
    /// </summary>
    /// <param name="mth_pos">Posição usada como referencia para achar o inimigo mais próximo</param>
    /// <returns></returns>
    public static Vector3 GetMoreClose(Vector3 mth_pos) {
        //A principio assume que o inimigo mais próximo é a posição 0.
        int tp_moreClose = 0; //Indice mais próximo.
        float tp_dis = Vector3.Distance(mth_pos, enemy[tp_moreClose].transform.position); //Menor distancia.

        //Depois verifica todas as outras posições para validar se existe um inimigo mais próximo do que o que foi determinado.
        for (int i = 1; i < enemy.Count; i++) {
            //Iguala a posição em z para ela não influenciar no calculo da distancia, já que o jogo tem uma visão de cima e a
            //profundidade não importa muito, pois se não iguarlar vai dar ruim se a posiçào em z dos inimigos forem diferentes, mais
            //caso o jogo tenha escadas pra subir e coisa do genéro, é melhor dirar essa linha.
            mth_pos.z = enemy[i].transform.position.z;
            float tp_newDis = Vector3.Distance(mth_pos, enemy[i].transform.position);

            //Se esse inimigo estiver mais próximo salva o indice dele para retornar sua posição no futuro e também salva a distancia
            //para facilitar o código e não precisar toda hora ficar calculando a distancia desse inimigo.
            if (tp_newDis < tp_dis) {
                tp_dis = tp_newDis;
                tp_moreClose = i;
            }
        }

        //Retorna a posição do inimigo mais oróximo
        return enemy[tp_moreClose].transform.position;
    }

    /// <summary>
    /// Subtrar um de tudo que eesta acima do indice passado como referencia.
    /// </summary>
    /// <param name="mth_indiceBase">Indice de referencia, tudo que estiver acima de mim é subtraido um</param>
    public static void SubtractIndex(int mth_indiceBase) {
        for (int i = mth_indiceBase; i < enemy.Count; i++) {
            enemy[i].myIndex--;
        }
    }
}

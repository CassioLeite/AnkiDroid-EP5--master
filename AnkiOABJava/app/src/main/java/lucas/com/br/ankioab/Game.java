package lucas.com.br.ankioab;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.*;
import java.util.*;

public class Game extends AppCompatActivity implements View.OnClickListener {
    private ArrayList<Carta> cardList;
    private Button showAnswer;
    private Button goToNextQuestion;
    private RelativeLayout firstGroup;
    private RelativeLayout secondGroup;
    private TextView question;
    private TextView answer;
    int aleatorio;
    Integer idBaralho;
    private boolean show = false;
    LerCartaTask lerCartaTask;
    int cont = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_game);

        Bundle bundleObject = getIntent().getExtras();
        //cardList = (ArrayList<Carta>) bundleObject.getSerializable("ID");

        idBaralho = (Integer) bundleObject.getSerializable("ID");
        lerCartaTask = new LerCartaTask();
        showAnswer = (Button) findViewById(R.id.btn_show_answer);
        showAnswer.setOnClickListener(this);

        goToNextQuestion = (Button) findViewById(R.id.btn_go_to_next_question);
        goToNextQuestion.setOnClickListener(this);

        firstGroup = (RelativeLayout) findViewById(R.id.layout_show_answer);
        secondGroup = (RelativeLayout) findViewById(R.id.layout_next_card);

        question = (TextView) findViewById(R.id.question);
        answer = (TextView) findViewById(R.id.answer);

        if(show){
            secondGroup.setVisibility(View.VISIBLE);
        }else{
            firstGroup.setVisibility(View.INVISIBLE);
        }

        loadCard();
    }

    @Override
    public void onClick(View v) {
        switch (v.getId()){
            case R.id.btn_show_answer:
                firstGroup.setVisibility(View.VISIBLE);
                secondGroup.setVisibility(View.INVISIBLE);
                show = true;
                break;
            case R.id.btn_go_to_next_question:
                firstGroup.setVisibility(View.INVISIBLE);
                secondGroup.setVisibility(View.VISIBLE);
                show = false;
                loadCard();
                break;
        }
    }

    private void loadCard(){
        List<Carta> cartas = lerCartaTask.doInBackground(idBaralho);
        Carta mostraCarta = new Carta();

        cont ++;
        question.setText("LOL");
        answer.setText(" Subtrair coisa móvel alheia, para si ou para outrem, mediante grave ameaça ou violencia a pessoa, ou depois de have-la, por qualquer meio, reduzido a impossibilidade de resistencia.");
    }
}

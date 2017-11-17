package lucas.com.br.ankioab;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

public class AdicionarCarta extends AppCompatActivity {

    Button addCarta;
    EditText card_front, card_back;
    CriarCartaTask criarCartaTask;
    Spinner spinnerBaralho;
    ListarBaralhoTask listarBaralhoTask;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_adicionar_carta);

        addCarta = (Button) findViewById(R.id.botaoAddCard);
        card_front = (EditText) findViewById(R.id.card_front);
        card_back = (EditText) findViewById(R.id.card_back);
        criarCartaTask = new CriarCartaTask();
        listarBaralhoTask = new ListarBaralhoTask();
        spinnerBaralho = (Spinner) findViewById(R.id.spinner);

        List<Baralho> baralhos = listarBaralho();
        ArrayAdapter<Baralho> arrayAdapter = new ArrayAdapter(this, android.R.layout.simple_list_item_1, baralhos);
        spinnerBaralho.setAdapter(arrayAdapter);
    }

    public List<Baralho> listarBaralho ()
    {
        List<Baralho> baralhos = listarBaralhoTask.doInBackground();
        return baralhos;
    }

    public void criarCarta (View v){
        String frenteCarta = card_front.getText().toString();
        String versoCarta = card_back.getText().toString();
        Carta novaCarta = new Carta();
        novaCarta.CodBaralho = spinnerBaralho.getId();
        novaCarta.Frente = frenteCarta;
        novaCarta.Verso = versoCarta;

        if (novaCarta != null) {
            if (frenteCarta != null) {
                if (versoCarta != null) {
                    criarCartaTask.doInBackground(novaCarta);
                }
                else {
                    Toast.makeText(this, "Verso da carta náo pode ser nulo!", Toast.LENGTH_SHORT).show();
                }
            } else {
                Toast.makeText(this, "Frente da carta náo pode ser nulo!", Toast.LENGTH_SHORT).show();
            }
        }
        else {
            Toast.makeText(this, "Carta Inválida", Toast.LENGTH_SHORT).show();
        }
    }
}

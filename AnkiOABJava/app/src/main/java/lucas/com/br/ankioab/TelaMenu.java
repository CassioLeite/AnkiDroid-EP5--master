package lucas.com.br.ankioab;

import android.content.Intent;
import android.os.*;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.*;

import java.io.Serializable;
import java.util.*;

public class TelaMenu extends AppCompatActivity {

    private ListarBaralhoTask listarBaralhoTask;
    private Button addCarta, addBaralho;
    private ListView listViewBaralho;
    private EditText frenteCarta, versoCarta, nomeBaralho;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_tela_menu);

        addCarta = (Button) findViewById(R.id.botaoAddCard);
        addBaralho = (Button) findViewById(R.id.botaoAddDeck);
        listViewBaralho = (ListView) findViewById(R.id.listBaralhos);
        frenteCarta = (EditText) findViewById(R.id.card_front);
        versoCarta = (EditText) findViewById(R.id.card_back);
        nomeBaralho = (EditText) findViewById(R.id.form_deck_name);
        listarBaralhoTask = new ListarBaralhoTask();

        // código para evitar erro de permissao no aplicativo android
        // ao acessar a internet:
        StrictMode.ThreadPolicy policy = new
                StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);

        final List<Baralho> baralhos = preencherLista();
        ArrayAdapter<Baralho> arrayAdapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, baralhos);
        listViewBaralho.setAdapter(arrayAdapter);

        listViewBaralho.setOnItemClickListener(new AdapterView.OnItemClickListener(){
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Baralho deck = (Baralho) listViewBaralho.getItemAtPosition(position);
                Toast.makeText(TelaMenu.this, deck.getCodBaralho() + " clicado", Toast.LENGTH_LONG).show();

                Intent telaGame = new Intent(TelaMenu.this, Game.class);
                Bundle bundle = new Bundle();
                bundle.putSerializable("ID", (Serializable) deck.getCodBaralho());
                telaGame.putExtras(bundle);
                startActivity(telaGame);
            }
        });
    }

    private List<Baralho> preencherLista() {
        List<Baralho> dados = listarBaralhoTask.doInBackground();
        return dados;
    }

    public void adicionarCarta(View v) {
        Intent addCarta = new Intent(this, AdicionarCarta.class);
        startActivity(addCarta);
    }

    public void adicionarBaralho(View v) {
        Intent addBaralho = new Intent(this, AdicionarBaralho.class);
        startActivity(addBaralho);
    }

}

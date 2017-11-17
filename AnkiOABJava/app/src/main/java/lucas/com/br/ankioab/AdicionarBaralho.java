package lucas.com.br.ankioab;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class AdicionarBaralho extends AppCompatActivity {

    Button addBaralho;
    EditText form_deck_name;
    CriarBaralhoTask criarBaralhoTask;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_adicionar_baralho);

        addBaralho = (Button) findViewById(R.id.botaoAddDeck);
        form_deck_name = (EditText) findViewById(R.id.form_deck_name);

        criarBaralhoTask = new CriarBaralhoTask();
    }

    public void criarBaralho(View v){
        Baralho baralho = new Baralho();
        baralho.setNomeBaralho(form_deck_name.getText().toString());
        criarBaralhoTask.doInBackground(baralho);
        Toast.makeText(this, "Baralho criado com sucesso!", Toast.LENGTH_SHORT).show();
        form_deck_name.setText("");
    }
}

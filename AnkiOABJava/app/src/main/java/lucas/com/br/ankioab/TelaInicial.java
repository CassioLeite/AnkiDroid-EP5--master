package lucas.com.br.ankioab;

import android.content.Intent;
import android.os.StrictMode;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class TelaInicial extends AppCompatActivity {


    LerUsuarioTask lerUsuarioTask;
    ExcluirUsuarioTask excluirUsuarioTask;
    CriarUsuarioTask criarUsuarioTask;
    AtualizarUsuarioTask atualizarUsuarioTask;
    EditText email, senha;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_tela_inicial);

        //nomeUsuario = (EditText) findViewById(R.id.editNomeUsuario);
        email = (EditText) findViewById(R.id.editEmail);
        senha = (EditText) findViewById(R.id.editSenha);
        //confirmarSenha = (EditText) findViewById(R.id.editConfirmarSenha);

        // código para evitar erro de permissao no aplicativo android
        // ao acessar a internet:
        StrictMode.ThreadPolicy policy = new
                StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);

        lerUsuarioTask = new LerUsuarioTask();
        excluirUsuarioTask = new ExcluirUsuarioTask();
        criarUsuarioTask = new CriarUsuarioTask();
        atualizarUsuarioTask = new AtualizarUsuarioTask();

    }

    public void consultar (View v){
        String emailUsuario =  email.getText().toString();
        String senhaUsuario = senha.getText().toString();

        Usuario confimarUsuario = lerUsuarioTask.doInBackground(emailUsuario);

        if (confimarUsuario != null) {
            String senhaOficial = confimarUsuario.getSenha().toString();
            if (senhaOficial.equals(senhaUsuario)) {
                Intent telaMenu = new Intent(this, TelaMenu.class);
                startActivity(telaMenu);
            } else {
                Toast.makeText(this, "Usuário ou senha inválido!", Toast.LENGTH_SHORT).show();
            }
        }
        else {
            Toast.makeText(this, "Usuário inválido!", Toast.LENGTH_SHORT).show();
        }
    }

    /*public void excluir (View v){
        Integer id =  Integer.valueOf(codigo.getText().toString());// recuperar e converter para inteiro o valor da EditText

        excluirUsuarioTask.doInBackground(id);
        Toast.makeText(this,"Usuário" + id+"excluído!", Toast.LENGTH_SHORT).show();
    }

    public void criar (View v){
        String senhaa = senha.getText().toString();
        String senhaaa = email.getText().toString();
        if (senhaa.equals(senhaaa))
        {
            Toast.makeText(this,"As senhas não correspondem!", Toast.LENGTH_SHORT).show();
        }
        else {
            Toast.makeText(this,"As senhas correspondem!", Toast.LENGTH_SHORT).show();
            //Usuario usuario = new Usuario();
            //usuario.setNomeUsuario(nomeUsuario.getText().toString());
            //usuario.setEmail(email.getText().toString());
            //usuario.setSenha(senha.getText().toString());
        }

        //criarUsuarioTask.doInBackground(usuario);
        //Toast.makeText(this,"Usuário criado com sucesso!", Toast.LENGTH_SHORT).show();

    }

    public void atualizar (View v){
        Usuario postagem = new Usuario();
        postagem.setCodUsuario(Integer.valueOf(codigo.getText().toString()));
        postagem.setCodUsuario(Integer.valueOf(editCodigoUsuario.getText().toString()));
        postagem.setEmail(editTitulo.getText().toString());
        postagem.setSenha(editConteudo.getText().toString());

        criarUsuarioTask.doInBackground(postagem);
        Toast.makeText(this,"Usuário criado com sucesso!", Toast.LENGTH_SHORT).show();
    }*/
}

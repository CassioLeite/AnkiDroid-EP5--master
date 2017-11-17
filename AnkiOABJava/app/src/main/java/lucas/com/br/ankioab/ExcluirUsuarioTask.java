package lucas.com.br.ankioab;

import android.content.Context;
import android.os.AsyncTask;
import feign.Feign;
import feign.gson.GsonDecoder;

/**
 * Created by aluno on 07/06/2017.
 */

public class ExcluirUsuarioTask extends AsyncTask<Integer, Void, Void> {

    Context context;
    String url = context.getString(R.string.url_api);

    @Override
    protected Void doInBackground(Integer... params) {
        try {
            // 1. usando a Feign para fazer uma chamada a uma api rest
            UsuarioRequest request = Feign.builder().
                    decoder(new GsonDecoder()).
                    target(UsuarioRequest.class, url);


            request.deleteUsuario(params[0]);
            return null;

        } catch (Exception e) {
            System.err.println("Erro ao tentar excluir Usuario!");
            e.printStackTrace();
            return null;
        }
    }

}

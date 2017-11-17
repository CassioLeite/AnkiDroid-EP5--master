package lucas.com.br.ankioab;

import android.content.Context;
import android.os.AsyncTask;

import feign.Feign;
import feign.gson.GsonDecoder;

/**
 * Created by aluno on 07/06/2017.
 */

public class ExcluirBaralhoTask extends AsyncTask<Integer, Void, Void> {

    Context context;
    String url = context.getString(R.string.url_api);

    @Override
    protected Void doInBackground(Integer... params) {
        try {
            // 1. usando a Feign para fazer uma chamada a uma api rest
            BaralhoRequest request = Feign.builder().
                    decoder(new GsonDecoder()).
                    target(BaralhoRequest.class, url);


            request.deleteBaralho(params[0]);
            return null;

        } catch (Exception e) {
            System.err.println("Erro ao tentar excluir Baralho!");
            e.printStackTrace();
            return null;
        }
    }
}

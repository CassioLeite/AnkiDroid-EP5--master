package lucas.com.br.ankioab;

import android.content.Context;
import android.os.AsyncTask;

import feign.Feign;
import feign.gson.GsonDecoder;

/**
 * Created by aluno on 07/06/2017.
 */

public class LerBaralhoTask extends AsyncTask<Integer, Void, Baralho> {

    Context context;
    String url = context.getString(R.string.url_api);

    @Override
    protected Baralho doInBackground(Integer... params) {
        try {
            // 1. usando a Feign para fazer uma chamada a uma api rest
            BaralhoRequest request = Feign.builder().
                    decoder(new GsonDecoder()).
                    target(BaralhoRequest.class, url);

            // 2. Fazendo a chamada e recuperando o objeto convertido
            Baralho baralho = request.getBaralho(params[0]);
            return baralho;

        } catch (Exception e) {
            System.err.println("Erro na chamada à API "+e.getMessage());
            e.printStackTrace();
            return null;
        }
    }
}

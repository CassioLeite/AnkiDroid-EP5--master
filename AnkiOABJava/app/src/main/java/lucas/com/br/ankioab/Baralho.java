package lucas.com.br.ankioab;

/**
 * Created by aluno on 07/06/2017.
 */

public class Baralho {

    private Integer CodBaralho ;
    private String NomeBaralho ;

    @Override
    public String toString() {
        return NomeBaralho;
    }

    public Integer getCodBaralho() {return CodBaralho;}

    public void setCodBaralho(Integer codBaralho) {this.CodBaralho = codBaralho;}

    public String getNomeBaralho() {return NomeBaralho;}

    public void setNomeBaralho(String nomeBaralho) {this.NomeBaralho = nomeBaralho;}

}

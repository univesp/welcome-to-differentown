# Welcome To Differentown
[Link do Recurso Educacional Aberto (REA)](https://apps.univesp.br/welcome-to-differentown/ "REA")

O objetivo deste recurso é oferecer ao jogador uma experiência interativa de uma viagem a um país estrangeiro. O público alvo são pessoas com inglês intermediário que tenham interesse de testar seus conhecimentos no idioma.
Nesse jogo, o jogador assume o controle de um personagem que viaja à Differentown, uma cidade fictícia dos Estados Unidos, e se depara com diversas situações em que é necessário praticar o seu inglês. Uma segunda personagem, amiga do personagem principal e moradora no país, oferece ajuda com as eventuais dificuldades ao longo do jogo.

O sistema programado nesse jogo pode ser adaptado de diversas formas, como:

1. Mudar o idioma do inglês para qualquer outro.

Para editar esse REA, você precisará estar familiarizado com Unity3d, C# e Json.

*Esse jogo foi desenvolvido em Unity3d 2018.2.12f1. Rodar esse projeto em outras versões da Unity pode causar erros que podem impedir o funcionamento correto do mesmo.

- - - -

## 1. Mudar o idioma ##

Todos os diálogos estão escritos em Json, com exceção dos textos dentro dos botões. Eles seguem obrigatoriamente a seguinte estrutura:
```
[
	{
        "nomePersonagem": "Officer",
        "jogadorFala": false,
        "expressao": "airport_cena1a_npc_conversa",
        "fala":[
             "Welcome to Differentown.",
			 "Name and passport, please?"
            ]
    }
]
```
* nomePersonagem: É o nome que vai aparecer acima da caixa de diálogo. Pode deixar esse campo em branco caso o diálogo seja do jogador.
* jogadorFala: É um bool que define se o diálogo é do jogador ou do NPC (jogador e NPCs tem caixas de diálogo diferentes).
* expressão: Essa é a imagem do NPC que vai aparecer na tela. O nome da expressão tem que ser exatamente o mesmo nome do sprite nos assets. Se o diálogo for do jogador, pode deixar esse campo em branco.
* fala: Aqui vão as falas que vão aparecer na tela. Cada frase separada por "", será mostrada individualmente.

Lembrando que se for alterar essa estrutura, será necessário alterar também a classe Fala.cs e os scripts DialogueBoxController.cs e DialogueController.cs.

# JobChatGPT

 Objetivo do projeto, prevê descrição e seus processos em 4 partes.. ( em desenvolvimento )
 
Projeto para trazer vagas de empregos de chats, grupos de Telegram, .. , etc. Analisar as mensagens com IA se for uma vaga, obter seus dados e extrair seus atributos correspondentes, realizar uma revisão dos dados e padronizar para deixar as vagas com boa qualidade

Processos:

1 - Recolher mensagens de grupos do Telegram de forma organizada e de fácil manutenção, como escolher grupos específicos para extrai suas mensagens até tantos dias atrás e atribuir na lista de mensagens.

2 - Analisar cada mensagem da lista de mensagens com ChatGPT, se for uma vaga, organizar suas informações para que fique claro onde está a função, desc... e atribuir após a analise na lista da vagas analisadas.

3 - Para cada vaga analisada extrair da resposta sua função, desc... para atribuir os atributos correspondentes da lista de vagas e fazer um tratamento e revisão dos dados visando a qualidade do Crawler.

4 - Mandar essa lista de vagas já revisadas para uma fila e obter na Auditoria e fazer seu tratamento de finalização e um pende fino antes de entrar no banco, e então deixar a vaga entrar no banco de dados.

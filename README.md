# Projeto Redirects
## Introdução
Recentemente finalizei meu estágio de programação em uma agência de marketing digital e posso dizer que foi uma das melhores experiências da minha vida. Eu aprendi muitas coisas na prática: desde trabalho em equipe e a importância dos prazos até como cada projeto se conecta para atender as necessidades dos clientes. Tanto foi meu aprendizado que ao final do meu contrato, já com dois anos de casa, eu me considerava um "estágiário sênior", participando ativamente em reuniões e sugerindo ideias novas sempre que podia. Em dois anos aprendi mais na prática do que em toda teoria da minha vida. Entretanto, como toda fase da vida, esta maravilhosa época chegou ao fim e me desliguei da empresa com excelentes lembranças e amigos para a vida toda, mas não antes de indicar e treinar uma pessoa de confiança que assumiria meu cargo. 

Até hoje mantenho contato diário com meus antigos companheiros de estágio e foi justamente em uma dessas conversas que chegamos ao ponto que deu origem ao **Projeto Redirect**: a necessidade de redirecionar múltiplas páginas de um site.

Para contextualizar é importante entender que toda boa agência de marketing digital se preocupa com o posicionamento dos clientes em mecanismos de busca como o Google e o Bing, e um dos muitos fatores que influenciam nesse _ranking_ é evitar erros de Página Não Encontrada (o famoso 404). É comum muitas URLs serem alteradas durante a reformulação de um site, e este cliente em particular possuia um catálogo virtual com mais de 500 produtos. Pois é, os estagiários teriam MUITO trabalho com este projeto, redirecionando cada página alterada para suas novas URLs. Um trabalho árduo, mas necessário. E foi aí que nós pensamos: mas será que não existe uma forma de automatizar esse processo? E aqui estamos!

## Overview
A necessidade de fazer o redirecionamento de páginas é muito simples: se uma página é removida de um site e o usuário tentar acessá-la, ele vai se deparar com um erro 404 bem incômodo.

![erro-404](https://user-images.githubusercontent.com/32982475/79689292-250bf780-822a-11ea-9e14-9311a8f0ac11.jpg)

Para resolver esta questão basta redirecionarmos o cliente para uma página nova assim que ele tentar acessar a antiga. Assim evitamos erros 404 e ganhamos uns pontinhos de SEO (se você não sabe o que é SEO acesse [este link](https://cintracomunicacao.com.br/consultoria-de-seo/) para entender do que estou falando).

### Problemática
Na teoria tudo é muito simples, mas e na prática? Para ilustrar melhor aonde quero chegar vamos imaginar um cenário no qual você está trabalhando em um projeto de reformulação de site com as seguintes etapas:

- [x] Reformular páginas de acordo com _Briefing_ passado pelo cliente
- [x] Criar novo sistema de organização dos produtos em categorias. Por exemplo: o produto localizado em **www<span></span>.sitedocliente.com.br/produto** seria movido para **www<span></span>.sitedocliente.com.br/categoria-do-produto/produto**.
- [ ] Redirecionar todas as URLs de produtos para seus novos endereços.

Como você pode perceber quase todas as etapas do seu projeto já foram concluídas e agora só falta redirecionar todos os produtos. Fazer isso é relativamente fácil, basta ter uma relação com as URLs antigas e novas para cada produto, desta forma:

| URL antiga | URL nova |
|:-:|:-:|
| `www.sitedocliente.com.br/produto-1` | `www.sitedocliente.com.br/categoria-1/produto-1` |
| `www.sitedocliente.com.br/produto-2` | `www.sitedocliente.com.br/categoria-1/produto-2` |
| `www.sitedocliente.com.br/produto-3` | `www.sitedocliente.com.br/categoria-2/produto-3` |

Com esta tabela em mãos basta escrever uma regra de redirecionamento para cada URL no arquivo de configuração do site. Para este exemplo vamos pensar em um arquivo **.htaccess** (se você não sabe o que é isso [dá uma olhada neste link](https://pt.wikipedia.org/wiki/.htaccess)). Os redirecionamentos seriam escritos desta forma:
```
redirect 301 /produto-1
http://www.sitedocliente.com.br/categoria-1/produto-1

redirect 301 /produto-2
http://www.sitedocliente.com.br/categoria-1/produto-2

redirect 301 /produto-3
http://www.sitedocliente.com.br/categoria-2/produto-3
```
Até agora parece tudo muito fácil, mas imagina uma situação em que o site possui mil ou mais produtos. Seria inviável relacionar produto por produto e escrever uma regra para redirecionar cada um deles. 

E chegamos finalmente na parte mais interessante!

### Proposta de Solução
A ideia é automatizar as etapas de relacionar as URLs do novo site em uma planilha e escrever os redirecionamentos propostos em um arquivo _.htaccess_. Para isso será necessário que o utilitário receba uma relação de URLs (antigas e novas) e tenha como saída dois arquivos, um contendo a relação de _redirects_ sugeridos e outro contendo o script para ser incluído no arquivo de configuração do site.

É possível obter uma relação automática das URLs através de um arquivo **sitemap.xml**, que pode ser gerado de forma automática. Todo o processamente será realizado com base nesses arquivos.

#### Protótipo
![prototipo-interface-jpg](https://user-images.githubusercontent.com/32982475/79693999-2ea25900-8244-11ea-988a-61776d5d1d7d.jpg)

#### Requisitos


#### Tecnologia utilizada
Tecnologias

### Algoritmos

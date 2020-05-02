# AssetoPBI

O projeto tem como objetivo utilizar os dados do jogo Assetto Corsa para criar uma telemetria em tempo real com o Power BI.

Mais informações no meu artigo https://www.linkedin.com/pulse/criando-uma-telemetria-e-conectando-em-tempo-real-o-power-tadeu-mansi/?published=t

Qualquer Dúvida pode me chamar no Linkedin https://www.linkedin.com/in/tadeu-mansi/

# Vídeo Demonstrativo

[![IMAGE ALT TEXT HERE](http://img.youtube.com/vi/cp3Jy8RePN0/0.jpg)](https://www.youtube.com/watch?v=cp3Jy8RePN0)

# Tutorial de configuração

### Criação das Bases


Primeiro você deve criar duas bases de conjunto de Streaming no Power BI Web, a base de dados do Carro e das Voltas.

Vá para o Power Bi Web, selecione o Workspace que você pretende criar esse exemplo, depois adicione um Conjunto de Dados de Streaming.

![github-small](https://i.imgur.com/oWS0p4w.png)

![github-small](https://i.imgur.com/R86VjyG.png)


### Criando Base dos dados do Carro

![github-small](https://i.imgur.com/YvJzmqs.jpg) 

Crie os campos conforme o esquema abaixo respeitando nomes e o tipo dos campos.

```
"Velocidade" : Número,
"RPM" : Número,
"Gasolina" : Número,
"Acelerador" : Número,
"Brake" : Número,
"Embragem" : Número,
"Marcha" : Número,
"DensidadeAR" : Número,
"TemperaturaAR" : Número,
"TemperaturaPista" : Número,
"DanoFrente" : Número,
"DanoTraseira" : Número,
"DanoLateralEsquerda" : Número,
"DanoLateralDireita" : Número,
"BrakeBias" : Número,
"TemperaturaBrakeFrenteEsquerdo" : Número,
"TemperaturaBrakeFrenteDireito" : Número,
"TemperaturaBrakeTraseiroEsquerdo" : Número,
"TemperaturaBrakeTraseiroDireito" : Número,
"PressaoPneuFrenteEsquerdo" : Número,
"PressaoPneuFrenteDireito" : Número,
"PressaoPneuTraseiroEsquerdo" : Número,
"PressaoPneuTraseiroDireito" : Número,
"TemperaturaPneuCoreFrenteEsquerdo" : Número,
"TemperaturaPneuCoreFrenteDireito" : Número,
"TemperaturaPneuCoreTraseiroEsquerdo" : Número,
"TemperaturaPneuCoreTraseiroDireito" : Número,
"TemperaturaPneuInteriorFrenteEsquerdo" : Número,
"TemperaturaPneuInteriorFrenteDireito" : Número,
"TemperaturaPneuInteriorTraseiroEsquerdo" : Número,
"TemperaturaPneuInteriorTraseiroDireito" : Número,
"TemperaturaPneuMeioFrenteEsquerdo" : Número,
"TemperaturaPneuMeioFrenteDireito" : Número,
"TemperaturaPneuMeioTraseiroEsquerdo" : Número,
"TemperaturaPneuMeioTraseiroDireito" : Número,
"TemperaturaPneuForaFrenteEsquerdo" : Número,
"TemperaturaPneuForaFrenteDireito" : Número,
"TemperaturaPneuForaTraseiroEsquerdo" : Número,
"TemperaturaPneuForaTraseiroDireito" : Número,
"DesgastePneuFrenteEsquerdo" : Número,
"DesgastePneuFrenteDireito" : Número,
"DesgastePneuTraseiroEsquerdo" : Número,
"DesgastePneuTraseiroDireito" : Número,
"Time" : DateTime
```
### Criando Base dos dados das Voltas

![github-small](https://i.imgur.com/8rg81YR.jpg) 

Crie os campos conforme o esquema abaixo respeitando nomes e o tipo dos campos.

```
"VoltasCompletadas" : Número,
"Posicao" : Número,
"VoltaCorrente" : Texto,
"UltimaVolta" : Texto,
"MelhorVolta" : Texto,
"Setor" : Número,
"TempoSetor" : Texto,
"UltimoTempoSetor" : Número,
"DistanciaPercorrida" : Número,
"TimeVolta" : DateTime
```
### Pegando as Urls das Bases de Dados

![github-small](https://i.imgur.com/XaPbLo2.png) 
![github-small](https://i.imgur.com/Lbca6Ds.jpg) 

Nessa etapa nós precisamos pegar a url das bases de dados, que confome a foto acima é a "Url de Push".
Copie essa Url de cada base.

### Configurando no Código
![github-small](https://i.imgur.com/VgkMFhV.jpg) 
Dentro do código cole essas Urls correspondente a cada variável no código do arquivo AssetoPBI.cs

```c#
 public static string UrlCarro = "COLOQUE A URL DA API DO POWERBI";
 public static string UrlVolta = "COLOQUE A URL DA API DO POWERBI";

```

### Criando um Painel no Power Bi Web

Dentro do Workspace crie um Painel.

![github-small](https://i.imgur.com/QRD2ghd.jpg) 

### Criando blocos com informações

Dentro do Painel, clique para Adicionar um Bloco.
Escolha a Opção de Dados em Tempo Real.

![github-small](https://i.imgur.com/z78Kld4.png) 

Esolha qual das duas bases de dados você quer criar uma visualização

![github-small](https://i.imgur.com/fy31CSq.png) 

Escolha os campos e o tipo da sua visualização

![github-small](https://i.imgur.com/SpAHLaC.jpg) 

Repita esse processo, com as informações que deseja vizualizar.

### Rode o Jogo

Abra o jogo Assetto Corsa (https://store.steampowered.com/app/244210/Assetto_Corsa/) e entre abra uma corrida ou um treino livre.

Compile o código desse projeto no Visual Studio ou em AssetoPBI/bin/Debug/netcoreapp3.1/Asseto.exe execute esse .exe e um console application irá se abrir indicando as requisições.

E pronto :) veja no Power BI Web os gráficos começarem a ser atualizados.

# Referências

Este projeto utiliza [essa biblioteca](https://github.com/mdjarv/assettocorsasharedmemory) (https://github.com/mdjarv/assettocorsasharedmemory) como base para o acesso aos dados da memória do jogo. 

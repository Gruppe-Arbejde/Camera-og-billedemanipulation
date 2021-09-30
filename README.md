# Webcam-opgave
Du skal i denne opgave lave en del forbedringer på koden. 
1. Sørg for at ”Capture knappen” kun kan trykkes på, når der er et billede på skærmen.  

2. Lav de 3 knapper i bunden samme størrelse og ret dem ind, så det ser pænt ud.  

3. Lav tre nye knapper, ”R-channel, G-channel, B-channel”, som skal bruge samme eventhandler, 
og de skal hver især vise et nyt billede i imgCapture, hvor modificeringen foregår på det forrige billede i imgCapture. 
Altså hvor henholdsvis R, G eller B kanalen er vist.

4. Så her skal der laves en ekstra Form, hvor der skal vises en miniudgave af billedet, 
og et billede med et histogram. Der skal laves en histogram måling af alle pixels i gråskala.  
![billede](https://user-images.githubusercontent.com/69769473/135424708-6a0876ac-29d7-48e4-a63b-c5fc386a5c76.png)

5. På den skala eller ”slider” man se på billedet herover, skal man vælge hvor man vil lægge ”skellet” mellem sort og hvid. 
På billedet til venstre vises resultatet af ens valg med slideren.

6. På det næste billede kan man se at nu bliver billederne fra webcameraet vist, som kun sort/hvid.   
Til sidst skal I ende op med et billede der kan vise hvor hovedvægten af pixels er. (Sorte eller hvide)  Så der skal laves en algoritme der kigger på tætheden af pixels i ”bundter/blobs/øer” og der hvor der 
er flest vises det enten på billedet eller som her under billedet med en streg.
![billede](https://user-images.githubusercontent.com/69769473/135424780-8e41ec7d-d3e6-4e94-9423-3d29f892ba14.png)

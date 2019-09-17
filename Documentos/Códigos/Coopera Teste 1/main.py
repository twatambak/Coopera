import pygame
from forma import *
#from planar import BoundingBox

pygame.init()

#=== Configuração da tela ====================================================================
# Realiza a configuração e ajuste inicial da tela
#=============================================================================================
frame = pygame.display.set_mode((1280, 720)) # Criação do frame
pygame.display.init()
pygame.display.set_caption("Coopera Teste 1") # Título da janela
#=============================================================================================


#=== Declaração das condições de loop ========================================================
# Faz a declaração das variáveis de loop para o jogo
#=============================================================================================
loop = 0 # Define o estado para o loop do jogo
timer = 360
run = True # Define o estado para o loop do jogo

#=============================================================================================


#=== Declaração das variáveis gerais =========================================================
# Faz a declaração das variáveis gerais utilizadas no jogo
#=============================================================================================
listaFormas = [] # Declara a lista de formas dentro da fase
listaDescartes = []
tamanhoLista = 0
#bbox = BoundingBox.from_shapes(listaFormas)
descarte = 120 # Área de descarte para criação das formas
pontosVerde = 0 # Pontos do time Verde
pontosAmarelo = 0 # Pontos do time Amarelo
fonteA = pygame.font.SysFont("Comic Sans", 40, True, False) # Fonte para o contador
fonteB = pygame.font.SysFont("Comic Sans", 40, False, False) # Fonte para os pontos
#=============================================================================================


#=== Declaração das funções ==================================================================
# Define as funções gerais utilizadas no jogo
#=============================================================================================
def atualizarTela(): # Atualiza as imagens da tela
	pygame.display.update() 
	pygame.draw.rect(frame, (89, 255, 0), (0, 0, 620, 40)) # Anterior 46, 107, 43
	pygame.draw.rect(frame, (255, 196, 0), (640, 0, 640, 40)) # Anterior 237, 192, 28
	pygame.draw.circle(frame, (56, 56, 56), (640, 0), 50 )

	textoTimer = fonteA.render("" + str(timer), 1, (255, 255, 255))

	textoPontosVerde = fonteB.render("PONTOS " + str(pontosVerde), 1, (0, 0, 0))
	textoPontosAmarelo = fonteB.render(str(pontosAmarelo) + " PONTOS", 1, (0, 0, 0))
	frame.blit(textoTimer, (615, 10))
	frame.blit(textoPontosVerde, (10, 10))
	frame.blit(textoPontosAmarelo, (1125, 10))

'''def atualizarBoundingBox():
	bbox = BoundingBox.from_shapes(listaFormas)'''
#=============================================================================================


#=== Loop do jogo ============================================================================
# Define os eventos e loop do jogo
#=============================================================================================
while run:
	pygame.time.delay(60)
	timer -= 1

	if loop >= 0: # Define o loop de criação dos quadrados
		loop += 1
	if loop > 10:
		loop = 0

	if loop == 0:
		if len (listaFormas) == 0: # A lista está vazia
			x = random.randint(0, 1280) # X recebe um valor aleatório
			y = random.randint(0, 720) # Y recebe um valor aleatório

			if y < 40 + descarte or y > 720 - descarte or x < 0 + descarte or x > 1280 - descarte:
				x = random.randint(0, 1280) # X recebe um valor aleatório
				y = random.randint(0, 720) # Y recebe um valor aleatório

			formaLegal = forma(frame, x, y, random.choice([40, 80, 120])) # Crio a forma
			listaDescartes.append((formaLegal.getX() + formaLegal.getTamanho(), formaLegal.getY() + formaLegal.getTamanho()))
			listaFormas.append(formaLegal) # Coloco a forma na lista
			tamanhoLista += 1
		else: # A lista não está vazia
			if len(listaFormas) < 5:
				x = random.randint(0, 1280) # X recebe um valor aleatório
				y = random.randint(0, 720) # Y recebe um valor aleatório
				for coordenada in listaDescartes:
					if y < 40 + descarte or y > 720 - descarte or x < 0 + descarte and x > 1280 - descarte or x == coordenada[0] or y == coordenada[1]:
						print("Entrou")
						x = random.randint(0, 1280) # X recebe um valor aleatório
						y = random.randint(0, 720) # Y recebe um valor aleatório

					formaLegal = forma(frame, x, y, random.choice([40, 80, 120])) # Crio a forma
					#listaDescartes.append((formaLegal.getX() + formaLegal.getTamanho(), formaLegal.getY() + formaLegal.getTamanho()))
					listaFormas.append(formaLegal) # Coloco a forma na lista
			else:
				listaFormas[0].apagar()
				print("X: ", listaFormas[0].getX())
				print("Y: ", listaFormas[0].getY())
				listaFormas.pop(0)


	'''if loop == 0:
		if len(listaFormas) < 5:
			x = random.randint(0, 1280) # X recebe um valor aleatório
			y = random.randint(0, 720) # Y recebe um valor aleatório
			formaLegal = forma(frame, y, x, random.choice([40, 80, 120])) # Crio a forma
			listaFormas.append(formaLegal) # Coloco a forma na lista
		else:
			listaFormas[0].apagar()
			print("X: ", listaFormas[0].getX())
			print("Y: ", listaFormas[0].getY())
			listaFormas.pop(0)'''

	'''if loop == 0:
		if len(listaFormas) < 5:
			x = random.randint(0, 1280) # X recebe um valor aleatório
			y = random.randint(0, 720) # Y recebe um valor aleatório
			
			while y < 40 + descarte or y > 720 - descarte or x < 0 + descarte or x > 1280 - descarte:
				print("Novo")
				x = random.randint(0, 1280) # X recebe um valor aleatório
				y = random.randint(0, 720) # Y recebe um valor aleatório

		# lista de valores não possíveis

			for formas in listaFormas:
				while (y < 60) or (y > 650) or (x < 20) or (x > 1180) and y formas.get():
					print("Novo")
					x = random.randint(0, 1280) # X recebe um valor aleatório
					y = random.randint(0, 720) # Y recebe um valor aleatório

			formaLegal = forma(frame, x, y, random.choice([40, 80, 120])) # Crio a forma
			listaFormas.append(formaLegal) # Coloco a forma na lista
		else:
			listaFormas[0].apagar()
			listaFormas.pop(0)'''

	'''if timer == 0:
		run = False'''

	for event in pygame.event.get():
		if event.type == pygame.QUIT:
			run = False

	for formas in listaFormas:
		if len(listaFormas) < 5:
			#formas.desenhar()
			pass

	atualizarTela()
#=============================================================================================

pygame.quit()

import pygame
import random

class forma(object):

#=== Declaração das variáveis da forma========================================================
# Declara as variáveis da forma
#=============================================================================================
	visibilidade = True # Definição de visibilidade (se a Forma está visível ou não)
	azul = (0, 60, 255) # Define o RGB da cor azul
	verde = (26, 189, 26) # Define o RGB da cor verde
	vermelho = (219, 13, 13) # Define o RGB da cor vermelho
	rosa = (250, 17, 157) # Define o RGB da cor rosa
	roxo = (117, 14, 235) # Define o RGB da cor roxo
	amarelo = (255, 221, 0) # Define o RGB da cor amarelo
	laranja = (255, 89, 0) # Define o RGB da cor laranja
	cores = [azul, verde, vermelho, rosa, roxo, amarelo, laranja] # Definição de uma lista com todas as cores definidas

	posX = 0
	posY = 0
	tamanho = 0
#=============================================================================================


#=== Definição da classe =====================================================================
# Realiza as definições de construção da classe
#=============================================================================================
	def __init__(self, frame, posX, posY, tamanho): # Construtor da Forma
		self.frame = frame
		self.posX = posX
		self.posY = posY
		self.tamanho = tamanho
		cor = random.choice(self.cores)
		visibilidade = True
		pygame.draw.rect(self.frame, cor, (posX, posY, tamanho, tamanho))
#=============================================================================================


#=== Métodos: Getters e Setters ==============================================================
# Declara os Getters e Setters para as variáveis da Forma
#=============================================================================================
	def getFrame(self): # Getter para o frame
		return self.frame

	def setFrame(self, frame): # Setter para o frame
		self.frame = frame

	def getX(self): # Getter para a posição X
		return self.posX

	def setX(self, x): # Setter para posição X
		self.posX = x

	def getY(self): # Getter para posição Y
		return self.posY

	def setY(self, y): # Setter para posição Y
		self.posY = y

	def getTamanho(self): # Getter para o tamanho
		return self.tamanho

	def setTamanho(self, tam): # Setter para o tamanho
		self.tamanho = tam

	def getCor(self): # Getter para a cor
		return self.cor

	def setCor(self, cor): # Setter para a cor
		self.cor = cor

	def getVisibilidade(self): # Getter para visibilidade
		return self.visibilidade

	def setVisibilidade(self, condicao): # Setter para visibilidade
		self.visibilidade = condicao
#=============================================================================================


#=== Métodos: Funções ========================================================================

	#def desenhar(self, tamanho): # Desenha a forma
		#pygame.draw.rect(self.frame, random.choice(self.cores), (self.posX, self.posY, tamanho, self.tamanho))

	def apagar(self):
		pygame.draw.rect(self.getFrame(), (0, 0, 0), (self.getX(), self.getY(), self.getTamanho(), self.getTamanho()))

#=============================================================================================
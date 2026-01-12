# Venda-de-Ingressos-Desafio-Tecnico
Mini sistema de venda de ingressos para cinema desenvolvido como desafio técnico, utilizando Angular no frontend e .NET (C#) no backend.
O sistema simula a seleção de assentos em uma sala de cinema com controle de reserva temporária, regras de bloqueio entre assentos e atualização visual em tempo real.

Tecnologias Utilizadas:

-> Front-End
- Angular (Standalone Components)
- TypeScript
- HTML5 / CSS3

-> Back-end 
- .NET 7+
- TypeScript
- HTML5/CSS3

Requisitos do Sistema: 
- O usuário seleciona um assento num mapa visual da sala e finaliza a "compra". ✅
- Quando o usuário clica no assento, ele fica "Reservado" para ele por apenas 2 minutos. Se ele não confirmar a compra (botão final) nesse tempo, o assento volta a ficar livre automaticamente. ✅
- O sistema não pode permitir que um usuário compre um assento que esteja imediatamente ao lado de um assento já ocupado, a menos que comprem juntos. ✅
- O mapa da sala deve atualizar as cores (Livre, Selecionado, Ocupado). ✅

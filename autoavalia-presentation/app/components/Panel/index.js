import React, { Component } from 'react';
import Header from '../Header';
import Footer from '../Footer';
import Card from '../Card';

export default class Panel extends Component {
	render() {
		return (
			<div className="page page--panel">
				<Header />
				<main className="main">
					<section className="section section--cards">
						<div className="container">
							<div className="cards">
								<Card title={"Histórico do veículo"} description={"Dados de documentação e uso"} cluster={"historic"} filledSteps={2} totalSteps={7} />
								<Card title={"Interior"} description={"Dados de documentação e uso"} cluster={"inside"} filledSteps={2} totalSteps={8} />
								<Card title={"Funilaria"} description={"Dados de documentação e uso"} cluster={"funnel"} filledSteps={2} totalSteps={9} />
								<Card title={"Pneus"} description={"Dados de documentação e uso"} cluster={"tires"} filledSteps={2} totalSteps={14} />
								<Card title={"Elétrica"} description={"Dados de documentação e uso"} cluster={"eletric"} filledSteps={2} totalSteps={5} />
								<Card title={"Mecânica"} description={"Dados de documentação e uso"} cluster={"mechanic"} filledSteps={2} totalSteps={6} />
							</div>
						</div>
					</section>
					<button className="button button--success">Continuar</button>
				</main>
				<Footer />
			</div>
		);
	}
}
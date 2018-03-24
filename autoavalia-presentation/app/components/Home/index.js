import React, { Component } from 'react';
import Header from '../Header';
import Footer from '../Footer';
import Card from '../Card';
import brandAutoAvalia from '../../../images/brands/brand-auto-avalia.svg';

export default class Home extends Component {
	render() {
		return (
			<div className="page page--home">
				<Header />
				<main className="main">
					<section className="section section--auto-avalia">
						<div className="container">
							<img className="brand-auto-avalia" src={brandAutoAvalia} />
							<h2 className="section__title">Auto avaliação Webmotors</h2>
							<p className="section__description">Para você que quer segurança na hora de comprar o veículo</p>
						</div>
					</section>
					<section className="section section--cards-auto-avalia">
						<div className="container">
							<div className="cards">
								<Card title={"Histórico do veículo"} description={"Trazemos para você as informações mais importantes sobre o veículo"} cluster={"historic"} />
								<Card title={"Avaliação do estado"} description={"Veja como está o estado de cada parte do veículo"} cluster={"valuation"} />
								<Card title={"Relátorio completo"} description={"Veja como está o estado de cada parte do veículo"} cluster={"report"} />
							</div>
						</div>
					</section>
					<section className="section section--valuation">
						<div className="container">
							<h2 className="section__title">Como deseja realizar a avaliação?</h2>
							<div className="buttons">
								<button className="button button--choose">Uma empresa</button>
								<button className="button button--choose">Eu mesmo</button>
							</div>
						</div>
					</section>
				</main>
				<Footer />
			</div>
		);
	}
}
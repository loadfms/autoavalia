import React, { Component } from 'react';
import Header from '../Header';
import Footer from '../Footer';
import brandAutoAvalia from '../../assets/images/brands/brand-auto-avalia.svg';

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
								<div className="cards__item">
									<h3 className="cards__item__title">Dica 1</h3>
									<p className="cards__item__description">Dados de documentação e uso Dados de documentação e uso</p>
								</div>
								<div className="cards__item">
									<h3 className="cards__item__title">Dica 1</h3>
									<p className="cards__item__description">Dados de documentação e uso Dados de documentação e uso</p>
								</div>
								<div className="cards__item">
									<h3 className="cards__item__title">Dica 1</h3>
									<p className="cards__item__description">Dados de documentação e uso Dados de documentação e uso</p>
								</div>															
							</div>
						</div>
					</section>
				</main>
				<Footer />
			</div>
		);
	}
}
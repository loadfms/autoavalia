import React, { Component } from 'react';
import Header from '../Header';
import Footer from '../Footer';

export default class Panel extends Component {
	render() {
		return (
			<div className="page page--panel">
				<Header />
				<main className="main">
					<section className="section section--cards">
						<div className="container">
							<div className="cards">
								<div className="cards__item cards__item--historic">
									<h3 className="cards__item__title">Hístorico do veículo</h3>
									<p className="cards__item__description">Dados de documentação e uso</p>								
								</div>
								<div className="cards__item cards__item--inside">
									<h3 className="cards__item__title">Interior</h3>
									<p className="cards__item__description">Dados de documentação e uso</p>								
								</div>
								<div className="cards__item cards__item--funnel">
									<h3 className="cards__item__title">Funilaria</h3>
									<p className="cards__item__description">Dados de documentação e uso</p>								
								</div>
								<div className="cards__item cards__item--tires">
									<h3 className="cards__item__title">Pneus</h3>
									<p className="cards__item__description">Dados de documentação e uso</p>								
								</div>
								<div className="cards__item cards__item--eletric">
									<h3 className="cards__item__title">Elétrica</h3>
									<p className="cards__item__description">Dados de documentação e uso</p>								
								</div>
								<div className="cards__item cards__item--mechanic">
									<h3 className="cards__item__title">Mecânica</h3>
									<p className="cards__item__description">Dados de documentação e uso</p>								
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
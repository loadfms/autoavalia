import React, { Component } from 'react';
import Header from '../Header';
import Footer from '../Footer';
import Progress from '../Progress';

export default class Question extends Component {
	render() {
		return (
			<div className="page page--question">
				<Header />
				<main className="main">
					<Progress filledSteps={2} totalSteps={10} />
					<section className="section section--question">
						<div className="container">
							<div className="question">
								<span className="question__icon">
									<span className="question__icon__image"></span>
								</span>
								<h2 className="question__title">Na lateral direita há algum destes problemas?</h2>
								<p className="question__description">Pintura não homogenêa • Riscos aparentes • Amassados • Bolhas na pintura</p>
							</div>
						</div>
					</section>
					<section className="section section--answer">
						<div className="container">
							<div className="answer">
								<div className="buttons">
									<button className="button button--choose">Sim</button>
									<button className="button button--choose">Não</button>
								</div>
							</div>
						</div>	
					</section>
				</main>
			</div>
		);
	}
}
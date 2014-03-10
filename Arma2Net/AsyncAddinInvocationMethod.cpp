/*
* Copyright 2013 Arma2NET Developers
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*     http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

#include "Utils.h"
#include "Addin.h"

using namespace System;
using namespace System::Collections::Concurrent;
using namespace System::Threading::Tasks;

namespace Arma2Net
{
	public ref class AsyncAddinInvocationMethod : public IAddinInvocationMethod
	{
	private:
		initonly Addin^ addin;
		initonly ConcurrentQueue<String^>^ results = gcnew ConcurrentQueue<String^>;
		Exception^ exception;

		void InvokeImpl(Object^ obj)
		{
			auto tuple = (Tuple<String^, int>^)obj;
			auto result = addin->Invoke(tuple->Item1, tuple->Item2);
			results->Enqueue(result);
		}

		bool HandleException(Exception^ e)
		{
			exception = e;
			return true;
		}

		String^ TaskFaulted(Task^ task)
		{
			task->Exception->Handle(gcnew Func<Exception^, bool>(this, &AsyncAddinInvocationMethod::HandleException));
			return nullptr;
		}
	public:
		AsyncAddinInvocationMethod(Addin^ addin)
		{
			this->addin = addin;
		}

		virtual String^ Invoke(String^ args, int maxResultSize)
		{
			if (args != nullptr && args->Equals("getresult", StringComparison::OrdinalIgnoreCase))
			{
				if (exception != nullptr)
				{
					Exception^ e = exception;
					exception = nullptr;
					throw e;
				}
					
				String^ result;
				results->TryDequeue(result);
				return result;
			}

			auto tuple = Tuple::Create(args, maxResultSize);
			auto task = gcnew Task(gcnew Action<Object^>(this, &AsyncAddinInvocationMethod::InvokeImpl), tuple);
			task->ContinueWith(gcnew Func<Task^, String^>(this, &AsyncAddinInvocationMethod::TaskFaulted), TaskContinuationOptions::OnlyOnFaulted);
			task->Start();
			return nullptr;
		}
	};
}